using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain;

namespace CommentModule.Domain;

class Comment : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid EntityId { get; set; }

    [Required]
    [MaxLength(500)]
    public string Text { get; set; }
    public bool IsActive { get; set; }
    public Guid? ParentId { get; set; }
    public CommentType CommentType { get; set; }


    [ForeignKey("ParentId")]
    public List<Comment> Replies { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}

public enum CommentType
{
    Course = 0,
    Article = 1
}