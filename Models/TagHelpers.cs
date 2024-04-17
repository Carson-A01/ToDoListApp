using Microsoft.AspNetCore.Razor.TagHelpers;
using Nest;

namespace ToDoListApp.Models
{
    public class TagHelpers
    {
        public class SubmitButtonTagHelper : TagHelper
        {
            public override void Process(TagHelperContext context,
            TagHelperOutput output)
            {
                // make it a button element with start and end tags
                output.TagName = "button";
                output.TagMode = TagMode.StartTagAndEndTag;
                // make it a submit button
                output.Attributes.SetAttribute("type", "submit");
                // append bootstrap button classes
                string newClasses = "btn btn-primary";
                string oldClasses =
                output.Attributes["class"]?.Value.ToString() ?? "";
                string classes = (string.IsNullOrEmpty(oldClasses)) ?
                newClasses : $"{oldClasses} {newClasses}";
                output.Attributes.SetAttribute("class", classes);
            }
        }
    }
}
