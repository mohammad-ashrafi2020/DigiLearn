using Common.Application;
using UserModule.Data.Entities._Enums;

namespace UserModule.Core.Commands.Roles.Edit;

public class EditRoleCommand : IBaseCommand
{
    public Guid RoleId { get; set; }
    public string Name { get; set; }
    public List<Permissions> Permissions { get; set; } = new();
}