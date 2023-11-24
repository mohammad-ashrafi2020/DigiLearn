using CommentModule.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Query.Filter;

namespace CommentModule.Services.DTOs;

public class CreateCommentCommand
{
    [Required]
    public string Text { get; set; }
    public Guid? ParentId { get; set; } = null;
    public Guid UserId { get; set; } = Guid.Empty;
    public Guid EntityId { get; set; }
    public CommentType CommentType { get; set; }
}
public class CommentDto
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid UserId { get; set; }
    public Guid EntityId { get; set; }

    [Required]
    [MaxLength(500)]
    public string Text { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public CommentType CommentType { get; set; }

    [ForeignKey("ParentId")]
    public List<CommentReplyDto> Replies { get; set; }
}

public class CommentReplyDto
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid UserId { get; set; }
    public Guid EntityId { get; set; }

    [Required]
    [MaxLength(500)]
    public string Text { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public Guid? ParentId { get; set; }
    public CommentType CommentType { get; set; }
}

public class CommentFilterResult : BaseFilter<CommentDto>
{
    public CommentFilterParams FilterParams { get; set; }
}
public class AllCommentFilterResult : BaseFilter<CommentReplyDto>
{

}

public class CommentFilterParams : BaseFilterParam
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CommentType? CommentType { get; set; } = null;
    public Guid? EntityId { get; set; } = null;

    [Display(Name = "نام")]
    public string? Name { get; set; }
    public string? Family { get; set; }
}