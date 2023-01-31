using Common.Application;
using CoreModule.Domain.Category.DomainServices;
using CoreModule.Domain.Category.Repository;

namespace CoreModule.Application.Category.Edit;

public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public EditCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetTracking(request.Id);
        if (category == null)
        {
            return OperationResult.NotFound();
        }
        category.Edit(request.Title, request.Slug, _categoryDomainService);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }
}