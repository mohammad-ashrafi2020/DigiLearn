using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DigiLearn.Web.TagHelpers;

public class DeleteItem : TagHelper
{

    public string Url { get; set; }
    public string Description { get; set; } = "";
    public string Class { get; set; } = "btn btn-danger btn-sm";
    public bool IsButtonTag { get; set; } = true;
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (IsButtonTag)
        {
            output.TagName = "button";
        }
        else
        {
            output.TagName = "a";
        }
        output.Attributes.Add("onClick", $"deleteItem('{Url}','{Description}')");
        output.Attributes.Add("class", Class);
        base.Process(context, output);
    }
}