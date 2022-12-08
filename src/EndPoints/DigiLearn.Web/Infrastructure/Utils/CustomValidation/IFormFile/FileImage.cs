using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DigiLearn.Web.Infrastructure.Utils.CustomValidation.IFormFile
{
    public class FileImageAttribute : ValidationAttribute, IClientModelValidator
    {
        public override bool IsValid(object? value)
        {
            var fileInput = value as Microsoft.AspNetCore.Http.IFormFile;
            if (fileInput == null)
                return true;

            return fileInput.IsImage();
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("accept", "image/*");
            context.Attributes.Add("data-val-fileImage", ErrorMessage);
        }
    }
    static class Validation
    {
        public static bool IsImage(this Microsoft.AspNetCore.Http.IFormFile file)
        {
            try
            {
                var img = Image.FromStream(file.OpenReadStream());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}