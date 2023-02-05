using Common.Domain;

namespace CoreModule.Infrastructure.Persistent.Users;

class User : BaseEntity
{
    public string PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string Avatar { get; set; }
    public string? Email { get; set; }

}