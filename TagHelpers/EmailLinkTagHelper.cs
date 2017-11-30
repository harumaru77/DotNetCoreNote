using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace DotNetNore.TagHelpers
{
    [HtmlTargetElement("el")]
    public class EmailLinkTagHelper : TagHelper
    {
        const string domain = "dotnetkorea.com";
        
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            string origin = (await output.GetChildContentAsync()).GetContent();
            string emailString = $"{origin}@{domain}";

            output.Attributes.Add("href", $"mailto:{emailString}");
            output.Content.SetContent(emailString);
        }
    }
}