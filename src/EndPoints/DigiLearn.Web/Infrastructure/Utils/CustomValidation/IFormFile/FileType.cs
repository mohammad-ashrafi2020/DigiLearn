#nullable enable
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DigiLearn.Web.Infrastructure.Utils.CustomValidation.IFormFile
{
    public class FileTypeAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileType">Example : png</param>
        public FileTypeAttribute(string fileType)
        {
            type = fileType;
        }
        public override bool IsValid(object? value)
        {
            var fileInput = value as Microsoft.AspNetCore.Http.IFormFile;
            if (fileInput == null) return true;


            var fileType = Path.GetExtension(fileInput.FileName);
            return fileType == $".{type}";
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("fileType", type);
            context.Attributes.Add("accept",$".{type}");
            context.Attributes.Add("data-val-fileType", ErrorMessage);
        }
    }
}