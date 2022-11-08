using Ganss.Xss;

namespace Common.Application.SecurityUtil
{
    public static class XssSecurity
    {
        public static string SanitizeText(this string text)
        {
            var htmlSanitizer = new HtmlSanitizer
            {
                KeepChildNodes = true,
                AllowDataAttributes = true
            };

            return htmlSanitizer.Sanitize(text);
        }
    }

}
