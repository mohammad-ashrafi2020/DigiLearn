using Microsoft.AspNetCore.Http;

namespace Common.Application.FileUtil;

public static class FileValidation
{
    public static bool IsValidFile(this IFormFile file)
    {
        if (file == null) return false;
        var path = Path.GetExtension(file.FileName);
        path = path.ToLower();
        if (path == ".mp4" || path == ".mp3" || path == ".zip" ||
            path == ".rar" || path == ".wav" || path == ".docx" ||
            path == ".mmf" || path == ".m4a" || path == ".ogg" ||
            path == ".doc" || path == ".pdf" || path == ".txt" ||
            path == ".xls" || path == ".xla" || path == ".xlsx" ||
            path == ".ppt" || path == ".pptx" || path == ".gif" ||
            path == ".jpg" || path == ".png" || path == ".tif" || path == ".wmv" ||
            path == ".bmp" || path == ".wmf" || path == ".gif" || path == ".log")
        {
            return true;
        }
        return false;
    }

    public static bool IsValidImageFile(string fileName)
    {
        if (string.IsNullOrEmpty(fileName)) return false;
        var path = Path.GetExtension(fileName);
        path = path.ToLower();
        if (path == ".jpg" || path == ".png" || path == ".bmp" || path == ".svg" || path == ".jpeg")
        {
            return true;
        }
        return false;
    }
}