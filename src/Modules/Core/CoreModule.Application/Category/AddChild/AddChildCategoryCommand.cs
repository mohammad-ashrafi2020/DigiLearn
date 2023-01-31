using Common.Application;

namespace CoreModule.Application.Category.AddChild;

public class AddChildCategoryCommand : IBaseCommand
{
    public Guid ParentCategoryId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
}