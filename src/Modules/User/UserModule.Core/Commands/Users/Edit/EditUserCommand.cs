using Common.Application;
using Common.EventBus.Abstractions;
using Common.EventBus.Events;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using UserModule.Data;

namespace UserModule.Core.Commands.Users.Edit;

public class EditUserCommand : IBaseCommand
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string? Email { get; set; }
}
public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly UserContext _context;
    private readonly IEventBus _eventBus;

    public EditUserCommandHandler(UserContext context, IEventBus eventBus)
    {
        _context = context;
        _eventBus = eventBus;
    }

    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f => f.Id == request.UserId, cancellationToken);
        if (user == null)
        {
            return OperationResult.NotFound();
        }
        user.Name = request.Name;
        user.Family = request.Family;
        if (string.IsNullOrWhiteSpace(request.Email) == false)
            user.Email = request.Email;
        await _context.SaveChangesAsync(cancellationToken);

        _eventBus.Publish(new UserEdited()
        {
            Email = user.Email,
            Family = user.Family,
            Name = user.Name,
            UserId = user.Id
        }, null, Exchanges.UserTopicExchange, ExchangeType.Topic, "user.edited");
        return OperationResult.Success();
    }
}
public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(f => f.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(f => f.Family)
            .NotEmpty()
            .NotNull();
    }
}