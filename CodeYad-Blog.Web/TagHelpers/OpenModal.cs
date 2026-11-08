using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Codeyad_Blog.Web.TagHelpers
{
    public class OpenModal:TagHelper
    {
        public string title { get; set; }
        public string url { get; set; }
        public string Class { get; set; } = "btn btn-primary";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.Add("OnClick",$"OpenModal('{url}','default-modal','{title}')");
            output.Attributes.Add("class",Class);
            base.Process(context, output);
        }
    }
}
