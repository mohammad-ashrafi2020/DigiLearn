using Common.Application;
using Common.Application.SecurityUtil;
using Common.EventBus.Abstractions;
using Common.EventBus.Events;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using UserModule.Data;
using UserModule.Data.Entities.Users;

namespace UserModule.Core.Commands.Users.Register;

public class RegisterUserCommand : IBaseCommand<Guid>
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}
public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand, Guid>
{
    private readonly UserContext _context;
    private readonly IEventBus _eventBus;
    public RegisterUserCommandHandler(UserContext context, IEventBus eventBus)
    {
        _context = context;
        _eventBus = eventBus;
    }

    public async Task<OperationResult<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _context.Users.AnyAsync(f => f.PhoneNumber == request.PhoneNumber))
        {
            return OperationResult<Guid>.Error("شماره تلفن تکراری است");
        }
        var user = new User()
        {
            PhoneNumber = request.PhoneNumber,
            Password = Sha256Hasher.Hash(request.Password),
            Avatar = "default.png",
            Id = Guid.NewGuid()
        };
        _context.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        _eventBus.Publish(new UserRegistered()
        {
            PhoneNumber = user.PhoneNumber,
            Avatar = user.Avatar,
            Email = user.Email,
            Family = user.Family,
            Name = user.Name,
            Password = user.Password,
            Id = user.Id
        }, null, Exchanges.UserTopicExchange, ExchangeType.Topic, "user.registered");
        return OperationResult<Guid>.Success(user.Id);
    }
}
public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(r => r.Password)
            .NotEmpty()
            .NotNull().MinimumLength(6);
    }
}