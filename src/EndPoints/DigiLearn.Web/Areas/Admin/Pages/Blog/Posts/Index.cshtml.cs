using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using BlogModule.Services;
using BlogModule.Services.DTOs.Command;
using BlogModule.Services.DTOs.Query;
using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModule.Core.Services;

namespace DigiLearn.Web.Areas.Admin.Pages.Blog.Posts;

public class IndexModel : BaseRazorFilter<BlogPostFilterParams>
{
    private IBlogService _blogService;
    private IUserFacade _userFacade;
    public IndexModel(IBlogService blogService, IUserFacade userFacade)
    {
        _blogService = blogService;
        _userFacade = userFacade;
    }


    public List<BlogCategoryDto> Categories { get; set; }
    public BlogPostFilterResult FilterResult { get; set; }



    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [BindProperty]
    public string Title { get; set; }

    [Display(Name = "نام نویسنده")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [BindProperty]
    public string OwnerName { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [UIHint("Ckeditor4")]
    [BindProperty]
    public string Description { get; set; }

    [Display(Name = "slug")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [BindProperty]
    public string Slug { get; set; }

    [Display(Name = "عکس مقاله")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [BindProperty]
    public IFormFile ImageFile { get; set; }


    [Display(Name = "دسته بندی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [BindProperty]
    public Guid CategoryId { get; set; }

    public async Task OnGet()
    {
        Categories = await _blogService.GetAllCategories();
        FilterResult = await _blogService.GetPostsByFilter(FilterParams);

        var user = await _userFacade.GetUserByPhoneNumber(User.GetPhoneNumber());
        if (user != null)
        {
            OwnerName = user.Name + " " + user.Family;
        }
    }

    public async Task<IActionResult> OnPost()
    {
        var result = await _blogService.CreatePost(new CreatePostCommand()
        {
            UserId = User.GetUserId(),
            OwnerName = OwnerName,
            CategoryId = CategoryId,
            Description = Description,
            Slug = Slug,
            Title = Title,
            ImageFile = ImageFile
        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
}