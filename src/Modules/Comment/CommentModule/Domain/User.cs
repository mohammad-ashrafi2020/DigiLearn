using Common.Domain;
using Microsoft.EntityFrameworkCore;

namespace CommentModule.Domain;

[Index("Email", IsUnique = true)]
class User : BaseEntity
{
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string Avatar { get; set; }
    public string? Email { get; set; }
}