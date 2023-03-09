using System.Drawing;
using Common.Application.FileUtil;
using Microsoft.AspNetCore.Http;

namespace Common.Application.SecurityUtil;

public static class ImageValidator
{
    public static bool IsImage(this IFormFile? file)
    {
        if (file == null)
            return false;

        return FileValidation.IsValidImageFile(file.FileName);
    }
}