using Common.Application;
using Common.Application.SecurityUtil;
using Common.Application.Validation.FluentValidations;
using Common.EventBus.Abstractions;
using Common.EventBus.Events;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using UserModule.Data;
using UserModule.Data.Entities.Users;

namespace UserModule.Core.Commands.Users.FullEdit;

public class FullEditUserCommand : IBaseCommand
{
    public Guid UserId { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? Password { get; set; }
    public List<Guid> Roles { get; set; }
}
public class FullEditUserCommandHandler : IBaseCommandHandler<FullEditUserCommand>
{
    private readonly UserContext _context;
    private readonly IEventBus _eventBus;

    public FullEditUserCommandHandler(UserContext context, IEventBus eventBus)
    {
        _context = context;
        _eventBus = eventBus;
    }

    public async Task<OperationResult> Handle(FullEditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(c => c.UserRoles)
            .FirstOrDefaultAsync(f => f.Id == request.UserId, cancellationToken);

        if (user == null)
        {
            return OperationResult.NotFound();
        }
        if (request.PhoneNumber != user.PhoneNumber &&
            await PhoneNumberIsDuplicated(request.PhoneNumber))
        {
            return OperationResult.Error("شماره تلفن تکراری است");
        }

        if (string.IsNullOrWhiteSpace(request.Email) == false)
        {
            if (request.Email.ToLower() != user.Email &&
                await EmailIsDuplicated(request.Email))
            {
                return OperationResult.Error("ایمیل وارد شده تکراری است");
            }
            user.Email = request.Email.ToLower();
        }

        if (string.IsNullOrWhiteSpace(request.Password) == false)
        {
            user.Password = Sha256Hasher.Hash(request.Password);
        }
        user.Name = request.Name;
        user.Family = request.Family;
        user.PhoneNumber = request.PhoneNumber;

        _context.UserRoles.RemoveRange(user.UserRoles);
        var userRoles = new List<UserRole>();
        foreach (var roleId in request.Roles)
        {
            userRoles.Add(new UserRole()
            {
                RoleId = roleId,
                UserId = user.Id
            });
        }

        _context.Users.Update(user);
        _context.UserRoles.AddRange(userRoles);
        await _context.SaveChangesAsync(cancellationToken);
        _eventBus.Publish(new UserEdited()
        {
            Email = user.Email,
            Family = user.Family,
            Name = user.Name,
            UserId = user.Id,
            PhoneNumber = user.PhoneNumber
        }, null, Exchanges.UserTopicExchange, ExchangeType.Topic, "user.edited");

        return OperationResult.Success();
    }
    private async Task<bool> EmailIsDuplicated(string email)
    {
        return await _context.Users.AnyAsync(f => f.Email == email.ToLower());
    }
    private async Task<bool> PhoneNumberIsDuplicated(string phoneNumber)
    {
        return await _context.Users.AnyAsync(f => f.PhoneNumber == phoneNumber);
    }
}
public class FullEditUserCommandValidator : AbstractValidator<FullEditUserCommand>
{
    public FullEditUserCommandValidator()
    {
        RuleFor(f => f.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .ValidPhoneNumber();


        RuleFor(f => f.Email)
            .EmailAddress();
    }
}