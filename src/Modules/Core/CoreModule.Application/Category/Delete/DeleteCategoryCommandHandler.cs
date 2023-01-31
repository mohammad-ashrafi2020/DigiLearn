using Common.Application;
using CoreModule.Domain.Category.Repository;

namespace CoreModule.Application.Category.Delete;

public class DeleteCategoryCommandHandler : IBaseCommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetTracking(request.CategoryId);
        if (category == null)
        {
            return OperationResult.NotFound();
        }

        await _categoryRepository.Delete(category);
        return OperationResult.Success();
    }
}