using AutoMapper;
using BlogModule.Domain;
using BlogModule.Repositories.Categories;
using BlogModule.Repositories.Posts;
using BlogModule.Services.DTOs.Command;
using BlogModule.Services.DTOs.Query;
using Common.Application;

namespace BlogModule.Services;

public interface IBlogService
{
    Task<OperationResult> CreateCategory(CreateCategoryCommand command);
    Task<OperationResult> EditCategory(EditCategoryCommand command);
    Task<OperationResult> DeleteCategory(Guid categoryId);
    Task<List<BlogCategoryDto>> GetAllCategories();
    Task<BlogCategoryDto> GetCategoryByIdTask(Guid id);
}
class BlogService : IBlogService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public BlogService(ICategoryRepository categoryRepository, IMapper mapper, IPostRepository postRepository)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<OperationResult> CreateCategory(CreateCategoryCommand command)
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

    public async Task<OperationResult> EditCategory(EditCategoryCommand command)
    {
        var category = await _categoryRepository.GetAsync(command.Id);
        if (category == null)
            return OperationResult.NotFound();

        if (command.Slug != category.Slug)
        {
            if (await _categoryRepository.ExistsAsync(f => f.Slug == category.Slug))
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

    public async Task<BlogCategoryDto> GetCategoryByIdTask(Guid id)
    {
        var category = await _categoryRepository.GetAsync(id);
        return _mapper.Map<BlogCategoryDto>(category);
    }
}