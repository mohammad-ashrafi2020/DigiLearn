using Common.Application;
using CoreModule.Domain.Category.DomainServices;
using CoreModule.Domain.Category.Models;
using CoreModule.Domain.Category.Repository;

namespace CoreModule.Application.Category.AddChild;

public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public AddChildCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new CourseCategory(request.Title, request.Slug, request.ParentCategoryId, _categoryDomainService);

        _categoryRepository.Add(category);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }
}