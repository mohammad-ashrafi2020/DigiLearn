using Common.Application;

namespace CoreModule.Application.Category.Delete;

public record DeleteCategoryCommand(Guid CategoryId) : IBaseCommand;