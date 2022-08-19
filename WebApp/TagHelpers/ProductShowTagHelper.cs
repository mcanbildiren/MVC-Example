using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Taghelpers
{
    public class ProductShowTagHelper : TagHelper
    {
        public ProductViewModel Product { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "div"; //<div></div>

            output.Content.SetHtmlContent(@$"
<ul>
    <li>{Product.Id}</li>
    <li>{Product.Name}</li>
    <li>{Product.Color}</li>
    <li>{Product.Category?.Name}</li>
</ul>");

        }
    }
}