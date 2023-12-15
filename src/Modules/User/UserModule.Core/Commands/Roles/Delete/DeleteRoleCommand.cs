using Common.Application;
using Microsoft.EntityFrameworkCore;
using UserModule.Data;
using UserModule.Data.Entities.Roles;

namespace UserModule.Core.Commands.Roles.Delete;

public record DeleteRoleCommand(Guid RoleId) : IBaseCommand;

class DeleteRoleCommandHandler : IBaseCommandHandler<DeleteRoleCommand>
{
    private readonly UserContext _context;

    public DeleteRoleCommandHandler(UserContext context)
    {
        _context = context;
    }

    public async Task<OperationResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(f => f.Id == request.RoleId, cancellationToken);
        if (role == null)
        {
            return OperationResult.NotFound();
        }

        if (await UsersHaveThisRole(role.Id))
        {
            return OperationResult.Error("امکان حذف این نقش وجود ندارد");
        }
        _context.Remove(role);
        await _context.SaveChangesAsync(cancellationToken);
        return OperationResult.Success();
    }

    private async Task<bool> UsersHaveThisRole(Guid roleId)
    {
        return await _context.UserRoles.AnyAsync(r => r.RoleId == roleId);
    }

}
