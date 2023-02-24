using Common.Domain.Utils;
using CoreModule.Domain.Category.DomainServices;
using CoreModule.Domain.Category.Repository;

namespace CoreModule.Application.Category;

public class CategoryDomainService : ICategoryDomainService
{
    private readonly ICourseCategoryRepository _repository;

    public CategoryDomainService(ICourseCategoryRepository repository)
    {
        _repository = repository;
    }

    public bool SlugIsExist(string slug)
    {
        return _repository.Exists(f => f.Slug == slug.ToSlug());
    }
}