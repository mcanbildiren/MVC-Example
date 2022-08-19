using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers
{
    public class ThumbnailImageTagHelper : TagHelper
    {
        public string ImageSrc { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            var lastIndex = ImageSrc.LastIndexOf('.');
            var fileName = ImageSrc.Substring(0, lastIndex);
            var fileExt = Path.GetExtension(ImageSrc);
            output.Attributes.SetAttribute("src", $"{fileName}-thumbnail{fileExt}");
        }
    }
}
