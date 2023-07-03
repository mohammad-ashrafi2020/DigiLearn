using Common.Query;

namespace CoreModule.Query._DTOs;

public class CoreModuleUserDto : BaseDto
{
    public string? Avatar { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
}