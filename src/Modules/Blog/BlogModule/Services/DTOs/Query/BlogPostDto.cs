using System.ComponentModel.DataAnnotations;

namespace BlogModule.Services.DTOs.Query;

public class BlogPostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid UserId { get; set; }
    public string OwnerName { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public long Visit { get; set; }
    public string ImageName { get; set; }
    public Guid CategoryId { get; set; }
}

