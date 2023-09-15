using BlogModule.Services;
using BlogModule.Services.DTOs.Query;
using CoreModule.Domain.Course.Enums;
using CoreModule.Facade.Course;
using CoreModule.Query.Course._DTOs;
using DigiLearn.Web.ViewModels;

namespace DigiLearn.Web.Infrastructure.Services
{
    public interface IHomePageService
    {
        Task<HomePageViewModel> GetData();
    }
    public class HomePageService : IHomePageService
    {
        private readonly ICourseFacade _courseFacade;
        private readonly IBlogService _blogService;
        public HomePageService(ICourseFacade courseFacade, IBlogService blogService)
        {
            _courseFacade = courseFacade;
            _blogService = blogService;
        }

        public async Task<HomePageViewModel> GetData()
        {
            var courses = await _courseFacade.GetCourseFilter(new CourseFilterParams()
            {
                Take = 8,
                ActionStatus = CourseActionStatus.Active,
                PageId = 1,
                FilterSort = CourseFilterSort.Latest
            });
            var posts = await _blogService.GetPostsByFilter(new BlogPostFilterParams()
            {
                Take = 6,
                PageId = 1,

            });
            var model = new HomePageViewModel()
            {
                LatestCourses = courses.Data.Select(s => new CourseCardViewModel
                {
                    Title = s.Title,
                    Slug = s.Slug,
                    ImageName = s.ImageName,
                    Price = s.Price,
                    Duration = s.GetDuration(),
                    Visit = 0,
                    CommentCounts = 0,
                    TeacherName = s.Teacher
                }).ToList(),
                LatestArticles = posts.Data
            };
            return model;
        }
    }
}
