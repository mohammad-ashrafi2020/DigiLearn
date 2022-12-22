using Common.Application;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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

    public EditUserCommandHandler(UserContext context)
    {
        _context = context;
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