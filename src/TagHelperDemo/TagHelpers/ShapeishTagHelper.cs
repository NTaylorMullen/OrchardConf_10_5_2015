using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace TagHelperDemo.TagHelpers
{
    public class ShapeishTagHelper : TagHelper
    {
        private readonly IViewComponentHelper _viewComponentHelper;

        public ShapeishTagHelper(IViewComponentHelper viewComponentHelper)
        {
            _viewComponentHelper = viewComponentHelper;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ((ICanHasViewContext)_viewComponentHelper).Contextualize(ViewContext);

            output.Content.SetContent(_viewComponentHelper.Invoke("Shapeish", Name, Age));

            output.TagName = null;
        }
    }
}
