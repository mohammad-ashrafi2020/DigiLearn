using Common.Domain;
using UserModule.Data.Entities.Roles;

namespace UserModule.Data.Entities.Users;

public class UserRole : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }


    public User User { get; set; }
    public Role Role { get; set; }
}