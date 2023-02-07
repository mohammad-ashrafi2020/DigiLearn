using Common.Application;
using CoreModule.Domain.Category.DomainServices;
using CoreModule.Domain.Category.Models;
using CoreModule.Domain.Category.Repository;

namespace CoreModule.Application.Category.AddChild;

public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand>
{
    private readonly ICourseCategoryRepository _courseCategoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public AddChildCategoryCommandHandler(ICourseCategoryRepository courseCategoryRepository, ICategoryDomainService categoryDomainService)
    {
        _courseCategoryRepository = courseCategoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new CourseCategory(request.Title, request.Slug, request.ParentCategoryId, _categoryDomainService);

        _courseCategoryRepository.Add(category);
        await _courseCategoryRepository.Save();
        return OperationResult.Success();
    }
}