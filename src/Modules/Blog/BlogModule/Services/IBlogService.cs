using AutoMapper;
using BlogModule.Context;
using BlogModule.Domain;
using BlogModule.Repositories.Categories;
using BlogModule.Repositories.Posts;
using BlogModule.Services.DTOs.Command;
using BlogModule.Services.DTOs.Query;
using BlogModule.Utils;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Microsoft.EntityFrameworkCore;

namespace BlogModule.Services;

public interface IBlogService
{
    Task<OperationResult> CreateCategory(CreateBlogCategoryCommand command);
    Task<OperationResult> EditCategory(EditBlogCategoryCommand command);
    Task<OperationResult> DeleteCategory(Guid categoryId);
    Task<List<BlogCategoryDto>> GetAllCategories();
    Task<BlogCategoryDto> GetCategoryById(Guid id);


    Task<OperationResult> CreatePost(CreatePostCommand command);
    Task<OperationResult> EditPost(EditPostCommand command);
    Task<OperationResult> DeletePost(Guid postId);
    Task<BlogPostDto?> GetPostById(Guid postId);
    Task<BlogPostFilterResult> GetPostsByFilter(BlogPostFilterParams filterParams);
}
class BlogService : IBlogService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly ILocalFileService _localFileService;
    private readonly BlogContext _context;
    public BlogService(ICategoryRepository categoryRepository, IMapper mapper, IPostRepository postRepository, ILocalFileService localFileService, BlogContext context)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _postRepository = postRepository;
        _localFileService = localFileService;
        _context = context;
    }

    public async Task<OperationResult> CreateCategory(CreateBlogCategoryCommand command)
    {
        var category = _mapper.Map<Category>(command);
        if (await _categoryRepository.ExistsAsync(f => f.Slug == category.Slug))
        {
            return OperationResult.Error("Slug is Exist");
        }

        _categoryRepository.Add(category);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }

    public async Task<OperationResult> EditCategory(EditBlogCategoryCommand command)
    {
        var category = await _categoryRepository.GetAsync(command.Id);
        if (category == null)
            return OperationResult.NotFound();

        if (command.Slug != category.Slug)
        {
            if (await _categoryRepository.ExistsAsync(f => f.Slug == command.Slug))
                return OperationResult.Error("Slug is Exist");
        }

        category.Slug = command.Slug;
        category.Title = command.Title;

        _categoryRepository.Update(category);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }

    public async Task<OperationResult> DeleteCategory(Guid categoryId)
    {
        var category = await _categoryRepository.GetAsync(categoryId);
        if (category == null)
            return OperationResult.NotFound();

        if (await _postRepository.ExistsAsync(f => f.CategoryId == categoryId))
            return OperationResult.Error("این دسته بندی قبلا استفاده شده است ، لطفا پست های مربوطه را حذف کنید و دوباره امتحان کنید");


        _categoryRepository.Delete(category);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }

    public async Task<List<BlogCategoryDto>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAll();

        return _mapper.Map<List<BlogCategoryDto>>(categories);
    }

    public async Task<BlogCategoryDto> GetCategoryById(Guid id)
    {
        var category = await _categoryRepository.GetAsync(id);
        return _mapper.Map<BlogCategoryDto>(category);
    }

    public async Task<OperationResult> CreatePost(CreatePostCommand command)
    {
        var post = _mapper.Map<Post>(command);
        if (await _postRepository.ExistsAsync(f => f.Slug == command.Slug))
            return OperationResult.Error("Slug is Exist");

        if (command.ImageFile.IsImage() == false)
            return OperationResult.Error("عکس وارد شده نامعتبر است");

        var imageName = await _localFileService.SaveFileAndGenerateName(command.ImageFile, BlogDirectories.PostImage);
        post.ImageName = imageName;
        post.Visit = 1;
        post.Description = post.Description.SanitizeText();

        _postRepository.Add(post);
        await _postRepository.Save();
        return OperationResult.Success();
    }

    public async Task<OperationResult> EditPost(EditPostCommand command)
    {
        var post = await _postRepository.GetTracking(command.Id);
        if (post == null) return OperationResult.NotFound();

        if (post.Slug != command.Slug)
            if (await _postRepository.ExistsAsync(f => f.Slug == command.Slug))
                return OperationResult.Error("Slug is Exist");

        if (command.ImageFile != null)
            if (command.ImageFile.IsImage() == false)
                return OperationResult.Error("عکس وارد شده نامعتبر است");
            else
            {
                var imageName = await _localFileService.SaveFileAndGenerateName(command.ImageFile, BlogDirectories.PostImage);
                post.ImageName = imageName;
            }

        post.Description = command.Description.SanitizeText();
        post.OwnerName = command.OwnerName;
        post.Title = command.Title;
        post.CategoryId = command.CategoryId;
        post.UserId = command.UserId;
        post.Slug = command.Slug;

        await _postRepository.Save();
        return OperationResult.Success();
    }

    public async Task<OperationResult> DeletePost(Guid postId)
    {
        var post = await _postRepository.GetAsync(postId);
        if (post == null) return OperationResult.NotFound();

        _postRepository.Delete(post);
        await _postRepository.Save();
        _localFileService.DeleteFile(BlogDirectories.PostImage, post.ImageName);
        return OperationResult.Success();
    }

    public async Task<BlogPostDto?> GetPostById(Guid postId)
    {
        var post = await _postRepository.GetAsync(postId);
        if (post == null)
            return null;

        return _mapper.Map<BlogPostDto>(post);
    }

    public async Task<BlogPostFilterResult> GetPostsByFilter(BlogPostFilterParams filterParams)
    {
        var result = _context.Posts.OrderByDescending(d => d.CreationDate)
            .Include(c => c.Category).AsQueryable();


        if (string.IsNullOrWhiteSpace(filterParams.Search) == false)
            result = result.Where(r =>
                r.Title.Contains(filterParams.Search) || r.Description.Contains(filterParams.Search));


        if (string.IsNullOrWhiteSpace(filterParams.CategorySlug) == false)
            result = result.Where(r => r.Category.Slug == filterParams.CategorySlug);


        var skip = (filterParams.PageId - 1) * filterParams.Take;
        var model = new BlogPostFilterResult()
        {
            Data = await result.Skip(skip).Take(filterParams.Take).Select(s => new BlogPostFilterItemDto
            {
                CreationDate = s.CreationDate,
                Id = s.Id,
                UserId = s.UserId,
                Title = s.Title,
                OwnerName = s.OwnerName,
                Description = s.Description,
                Slug = s.Slug,
                Visit = s.Visit,
                ImageName = s.ImageName,
                Category = new BlogCategoryDto()
                {
                    Title = s.Category.Title,
                    Id = s.CategoryId,
                    Slug = s.Category.Slug
                }
            }).ToListAsync()
        };

        model.GeneratePaging(result, filterParams.Take, filterParams.PageId);
        return model;

    }
}