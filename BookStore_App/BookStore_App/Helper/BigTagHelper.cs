using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Helper
{
    [HtmlTargetElement("big")]
    [HtmlTargetElement(Attributes ="big")]
    public class BigTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Replace any "big" html tag and attribute to h3 and apply an attribute class = "h3"
            output.TagName = "h3";
            output.Attributes.RemoveAll("big");
            output.Attributes.SetAttribute("class", "h3");
        }
    }
}
