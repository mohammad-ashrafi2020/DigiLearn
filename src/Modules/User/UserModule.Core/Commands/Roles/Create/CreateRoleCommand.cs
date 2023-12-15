using Common.Application;
using UserModule.Data.Entities._Enums;

namespace UserModule.Core.Commands.Roles.Create;

public class CreateRoleCommand : IBaseCommand
{
    public string Name { get; set; }
    public List<Permissions> Permissions { get; set; } = new();
}