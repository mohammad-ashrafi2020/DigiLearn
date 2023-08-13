using Common.Query;
using Common.Query.Filter;

namespace BlogModule.Services.DTOs.Query;

public class BlogPostFilterResult : BaseFilter<BlogPostFilterItemDto>
{

}

public class BlogPostFilterParams : BaseFilterParam
{
    public string? Search { get; set; }
    public string? CategorySlug { get; set; }
}
public class BlogPostFilterItemDto : BaseDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string OwnerName { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public long Visit { get; set; }
    public string ImageName { get; set; }
    public BlogCategoryDto Category { get; set; }
}