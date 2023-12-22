using System.ComponentModel.DataAnnotations;
using UserModule.Data.Entities._Enums;

namespace DigiLearn.Web.ViewModels.Admin;

public class EditRoleViewModel
{
    public Guid RoleId { get; set; }
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Name { get; set; }
    public List<Permissions> SelectedPermissions { get; set; } = new();

}