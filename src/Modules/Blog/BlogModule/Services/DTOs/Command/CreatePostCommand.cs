using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BlogModule.Services.DTOs.Command;

public class CreatePostCommand
{
    public string Title { get; set; }
    public Guid UserId { get; set; }
    public string OwnerName { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public IFormFile ImageFile { get; set; }
    public Guid CategoryId { get; set; }
}
public class EditPostCommand
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string OwnerName { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public IFormFile? ImageFile { get; set; }
}