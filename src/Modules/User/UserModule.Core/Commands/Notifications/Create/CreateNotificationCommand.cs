using FluentValidation;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Common.Application;
using UserModule.Data;
using UserModule.Data.Entities.Notifications;

namespace UserModule.Core.Commands.Notifications.Create;

public class CreateNotificationCommand : IBaseCommand
{
    public Guid UserId { get; set; }
    public string Text { get; set; }
    public string Title { get; set; }
}
public class CreateNotificationCommandHandler : IBaseCommandHandler<CreateNotificationCommand>
{
    private readonly UserContext _context;
    private readonly IMapper _mapper;
    public CreateNotificationCommandHandler(UserContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<UserNotification>(request);

        _context.Notifications.Add(model);
        await _context.SaveChangesAsync(cancellationToken);

        return OperationResult.Success();
    }
}

public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotEmpty()
            .NotNull();

        RuleFor(r => r.Text)
            .NotEmpty()
            .NotNull();
    }
}