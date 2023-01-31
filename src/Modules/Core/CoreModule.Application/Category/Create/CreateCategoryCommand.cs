using Common.Application;

namespace CoreModule.Application.Category.Create;

public class CreateCategoryCommand : IBaseCommand
{
    public string Title { get; set; }
    public string Slug { get; set; }
}
