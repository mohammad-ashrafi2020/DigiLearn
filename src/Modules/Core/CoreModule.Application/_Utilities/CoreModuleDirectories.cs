namespace CoreModule.Application._Utilities;

public class CoreModuleDirectories
{

    public static string FTP_Domain = "http";

    public static string CvFileNames = "wwwroot/core/teacher";
    public static string CourseImage = "wwwroot/core/course";
    public static string CourseDemo(Guid courseId) => $"wwwroot/core/course/{courseId}";
    public static string CourseEpisode(Guid courseId, Guid episodeToken) => $"wwwroot/core/course/{courseId}/episodes/{episodeToken}";

    public static string GetCourseImage(string imageName) => $"{CourseImage.Replace("wwwroot", "")}/{imageName}";
    public static string GetCvFile(string fileName) => $"{CvFileNames.Replace("wwwroot", "")}/{fileName}";

    public static string GetEpisodeFile(Guid courseId, Guid episodeToken, string fileName)
        => $"{CourseEpisode(courseId, episodeToken).Replace("wwwroot", "")}/{fileName}";

 

    public static string GetCourseDemo(Guid courseId,string fileName)
        => $"{CourseDemo(courseId).Replace("wwwroot", "")}/{fileName}";

}