using CommentModule.Domain;

namespace DigiLearn.WebApi.Models.Comment
{
    public class CreateCommentViewModel
    {
        public string Text { get; set; }
        public Guid? ParentId { get; set; } = null;
        public Guid EntityId { get; set; }
        public CommentType CommentType { get; set; }
    }
}
