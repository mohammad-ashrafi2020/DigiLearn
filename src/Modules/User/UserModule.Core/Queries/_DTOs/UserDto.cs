using System.ComponentModel.DataAnnotations;
using Common.Query.Filter;

namespace UserModule.Core.Queries._DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string? Name { get; set; }

    public string? Family { get; set; }

    public string PhoneNumber { get; set; }
    public string? Email { get; set; }

    public string Password { get; set; }

    public string Avatar { get; set; }
    public List<RoleDto> Roles { get; set; } = new();


    public string FullName => $"{Name} {Family}";
}

public class RoleDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}

public class UserFilterResult : BaseFilter<UserDto>
{

}

public class UserFilterParams : BaseFilterParam
{
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}