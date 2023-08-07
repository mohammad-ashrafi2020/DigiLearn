namespace BlogModule.Services.DTOs.Command;

public class CreateBlogCategoryCommand
{
    public string Title { get; set; }
    public string Slug { get; set; }
}
public class EditBlogCategoryCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
}
