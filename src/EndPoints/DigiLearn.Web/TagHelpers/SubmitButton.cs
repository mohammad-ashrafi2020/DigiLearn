using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DigiLearn.Web.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("submit", TagStructure = TagStructure.WithoutEndTag)]
    public class SubmitButton : TagHelper
    {
        public string Text { get; set; } = "ثبت اطلاعات";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.Add("class", "btn btn-success shadow");
            output.Attributes.Add("type", "submit");
            output.Attributes.Add("value", Text);
        }
    }
}
