using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MvcUIApp.Models;

namespace MvcUIApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper:TagHelper
    {
        private readonly IUrlHelperFactory _helperFactory;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public Pagination PageModel { get; set; }
        public string? PageAction { get; set; }

        public PaginationTagHelper(IUrlHelperFactory helperFactory)
        {
            _helperFactory = helperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _helperFactory.GetUrlHelper(ViewContext);

            // content 
            TagBuilder content = new TagBuilder("div");
            content.Attributes.Add("class", "pagination d-flex justify-content-center mt-5");
            for(int i = 1; i<=PageModel.TotalPages; i++)
            {
                TagBuilder linkTag = new TagBuilder("a");
                linkTag.AddCssClass("rounded");
                linkTag.AddCssClass(i == PageModel.CurrentPage ? "active": "");
                linkTag.Attributes["href"] = urlHelper.Action(PageAction, new {PageNumber = i});
                linkTag.InnerHtml.AppendHtml(i.ToString());

                content.InnerHtml.AppendHtml(linkTag);
            }
            output.Content.AppendHtml(content);
        }

        /*
         <div class="col-12">
                                <div class="pagination d-flex justify-content-center mt-5">
                                    <a href="#" class="rounded">&laquo;</a>
                                    <a href="#" class="active rounded">1</a>
                                    <a href="#" class="rounded">2</a>
                                    <a href="#" class="rounded">3</a>
                                    <a href="#" class="rounded">4</a>
                                    <a href="#" class="rounded">5</a>
                                    <a href="#" class="rounded">6</a>
                                    <a href="#" class="rounded">&raquo;</a>
                                </div>
            </div>
        */
    }
}