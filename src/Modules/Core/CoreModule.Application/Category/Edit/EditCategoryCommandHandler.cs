using Common.Application;
using CoreModule.Domain.Category.DomainServices;
using CoreModule.Domain.Category.Repository;

namespace CoreModule.Application.Category.Edit;

public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
{
    private readonly ICourseCategoryRepository _courseCategoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public EditCategoryCommandHandler(ICourseCategoryRepository courseCategoryRepository, ICategoryDomainService categoryDomainService)
    {
        _courseCategoryRepository = courseCategoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _courseCategoryRepository.GetTracking(request.Id);
        if (category == null)
        {
            return OperationResult.NotFound();
        }
        category.Edit(request.Title, request.Slug, _categoryDomainService);
        await _courseCategoryRepository.Save();
        return OperationResult.Success();
    }
}