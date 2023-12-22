using Common.Application;
using Microsoft.EntityFrameworkCore;
using UserModule.Core.Commands.Roles.Create;
using UserModule.Data;
using UserModule.Data.Entities.Roles;

namespace UserModule.Core.Commands.Roles.Edit;

class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
{
    private readonly UserContext _context;

    public EditRoleCommandHandler(UserContext context)
    {
        _context = context;
    }

    public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        if (request.Permissions.Count == 0)
        {
            return OperationResult.Error("لطفا دسترسی ها را مشخص کنید");
        }

        var role = await _context.Roles
            .Include(r => r.Permissions)
            .FirstOrDefaultAsync(f => f.Id == request.RoleId, cancellationToken);
        if (role == null)
        {
            return OperationResult.NotFound();
        }


        if (role.Name != request.Name)
        {
            var roleIsExist = await _context.Roles.AnyAsync(f => f.Name == request.Name, cancellationToken: cancellationToken);
            if (roleIsExist)
            {
                return OperationResult.Error("این نقش قبلا ساخته شده است");
            }
        }

        role.Name = request.Name;
        _context.Roles.Update(role);

        _context.RolePermissions.RemoveRange(role.Permissions);
        foreach (var permission in request.Permissions)
        {
            _context.RolePermissions.Add(new RolePermission()
            {
                RoleId = role.Id,
                Permissions = permission
            });
        }
        await _context.SaveChangesAsync(cancellationToken);
        return OperationResult.Success();
    }
}