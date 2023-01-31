using Common.Application;

namespace CoreModule.Application.Category.Edit;

public class EditCategoryCommand : IBaseCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
}