using Common.Application;
using CoreModule.Domain.Category.DomainServices;
using CoreModule.Domain.Category.Models;
using CoreModule.Domain.Category.Repository;

namespace CoreModule.Application.Category.Create;

public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
{
    private readonly ICourseCategoryRepository _courseCategoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public CreateCategoryCommandHandler(ICourseCategoryRepository courseCategoryRepository, ICategoryDomainService categoryDomainService)
    {
        _courseCategoryRepository = courseCategoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new CourseCategory(request.Title, request.Slug, null, _categoryDomainService);

        _courseCategoryRepository.Add(category);
        await _courseCategoryRepository.Save();
        return OperationResult.Success();
    }
}