namespace CoreModule.Application._Utilities;

public class CoreModuleDirectories
{



    public static string CvFileNames = "wwwroot/core/teacher";
    public static string CourseImage = "wwwroot/core/course";
    public static string CourseDemo(Guid courseId) => $"wwwroot/course/{courseId}";
    public static string CourseEpisode(Guid courseId, Guid episodeToken) => $"wwwroot/course/{courseId}/episodes/{episodeToken}";

    public static string GetCourseImage(string imageName) => $"{CourseImage.Replace("wwwroot", "")}/{imageName}";

}