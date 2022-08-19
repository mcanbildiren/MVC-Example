using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers
{
    public class CustomItalicTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<i>");
            output.PostContent.SetHtmlContent("</i>");
        }
    }
}
