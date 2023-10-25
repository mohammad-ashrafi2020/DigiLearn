using System.ComponentModel.DataAnnotations;
using Common.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Infrastructure.Persistent.Users;



[Index("Email", IsUnique = true)]
[Index("PhoneNumber", IsUnique = true)]
public class User : BaseEntity
{
    [MaxLength(12)]
    public string PhoneNumber { get; set; }

    [MaxLength(50)]
    public string? Name { get; set; }

    [MaxLength(50)]
    public string? Family { get; set; }
    [MaxLength(110)]
    public string? Avatar { get; set; }

    [MaxLength(110)]
    public string? Email { get; set; }

}