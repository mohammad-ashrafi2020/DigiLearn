using BlogModule.Services.DTOs.Query;
using CoreModule.Query.Category._DTOs;
using CoreModule.Query.Course._DTOs;

namespace DigiLearn.Web.ViewModels
{
    public class HomePageViewModel
    {
        public List<CourseCardViewModel> LatestCourses { get; set; }
        public List<BlogPostFilterItemDto> LatestArticles { get; set; }
    }

    public class CourseCardViewModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ImageName { get; set; }
        public int Price { get; set; }
        public string Duration { get; set; }
        public int Visit { get; set; }
        public int CommentCounts { get; set; }
        public string TeacherName { get; set; }
    }
}
