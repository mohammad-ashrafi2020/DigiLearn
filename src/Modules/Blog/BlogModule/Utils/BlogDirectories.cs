namespace BlogModule.Utils;

public class BlogDirectories
{
    public static string PostImage = "wwwroot/blog/images";
    public static string GetPostImage(string imageName)
    {
        return $"{PostImage.Replace("wwwroot", "")}/{imageName}";
    }
}