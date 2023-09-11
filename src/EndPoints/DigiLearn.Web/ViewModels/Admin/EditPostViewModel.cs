using System.ComponentModel.DataAnnotations;
using BlogModule.Services.DTOs.Query;

namespace DigiLearn.Web.ViewModels.Admin;
public class EditPostViewModel
{
    public List<BlogCategoryDto>? Categories { get; set; } = new List<BlogCategoryDto>();
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }
    public Guid UserId { get; set; }

    [Display(Name = "نام نویسنده")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string OwnerName { get; set; }

    [Display(Name = "توئضیحات")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [UIHint("Ckeditor4")]
    public string Description { get; set; }

    [Display(Name = "slug")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Slug { get; set; }
    public IFormFile? ImageFile { get; set; }
}
