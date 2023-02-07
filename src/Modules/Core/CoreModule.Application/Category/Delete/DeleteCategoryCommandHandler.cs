using Common.Application;
using CoreModule.Domain.Category.Repository;

namespace CoreModule.Application.Category.Delete;

public class DeleteCategoryCommandHandler : IBaseCommandHandler<DeleteCategoryCommand>
{
    private readonly ICourseCategoryRepository _courseCategoryRepository;

    public DeleteCategoryCommandHandler(ICourseCategoryRepository courseCategoryRepository)
    {
        _courseCategoryRepository = courseCategoryRepository;
    }

    public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _courseCategoryRepository.GetTracking(request.CategoryId);
        if (category == null)
        {
            return OperationResult.NotFound();
        }

        await _courseCategoryRepository.Delete(category);
        return OperationResult.Success();
    }
}