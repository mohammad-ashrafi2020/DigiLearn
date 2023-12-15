using System.ComponentModel.DataAnnotations;
using Common.Domain;

namespace UserModule.Data.Entities.Roles;

public class Role : BaseEntity
{

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }


    public List<RolePermission> Permissions { get; set; }
}