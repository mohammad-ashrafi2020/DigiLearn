namespace DigiLearn.WebApi.Models.Blog
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public IFormFile ImageFile { get; set; }
        public Guid CategoryId { get; set; }
    }

}
