using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace MvcUIApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes ="products")]
    public class LatestProductTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;

        [HtmlAttributeName("number")]
        public int Number { get; set; }

        public LatestProductTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "col-lg-12");
            var products = _manager.Product.GetLatestProducts(Number, false);
            foreach (var product in products)
            {
                TagBuilder dflex = new TagBuilder("div");
                dflex.Attributes.Add("class", "d-flex align-items-center justify-content-start");

                // Image div Tag
                TagBuilder imgDiv = new TagBuilder("div");
                imgDiv.Attributes.Add("class", "rounded me-4");
                imgDiv.Attributes.Add("style", "width: 100px; height: 100px;");
                TagBuilder img = new TagBuilder("img");
                img.Attributes.Add("class", "img-fluid rounded");
                img.Attributes.Add("src", $"/{product.ImageUrl}");
                img.Attributes.Add("alt", $"{product.ImageUrl}");
                imgDiv.InnerHtml.AppendHtml(img);



                // sc div
                TagBuilder scDiv = new TagBuilder("div");



                TagBuilder h6 = new TagBuilder("h6");
                h6.Attributes.Add("class", "mb-2");
                h6.InnerHtml.AppendHtml($"{product.Name}");
                

                TagBuilder dateDiv = new TagBuilder("div");
                dateDiv.Attributes.Add("class", "d-flex mb-2");
                TagBuilder span = new TagBuilder("span");
                span.Attributes.Add("class", "text-secondary");
                span.InnerHtml.AppendHtml($"{product.CreatedAt.ToString("dd.MM.yyyy")}");
                dateDiv.InnerHtml.AppendHtml(span);
                
                TagBuilder mdiv = new TagBuilder("div");
                mdiv.Attributes.Add("class", "mb-2 d-flex");
                TagBuilder h5price = new TagBuilder("h5");
                h5price.Attributes.Add("class", "fw-bold me-2");
                h5price.InnerHtml.AppendHtml($"{product.UnitPrice}₺");
                mdiv.InnerHtml.AppendHtml(h5price);

                scDiv.InnerHtml.AppendHtml(h6);
                scDiv.InnerHtml.AppendHtml(dateDiv);
                scDiv.InnerHtml.AppendHtml(mdiv);

                

                dflex.InnerHtml.AppendHtml(imgDiv);
                dflex.InnerHtml.AppendHtml(scDiv);

                div.InnerHtml.AppendHtml(dflex);

            }
            output.Content.AppendHtml(div);
        }
        /*
        <div class="d-flex align-items-center justify-content-start">
                                    <div class="rounded me-4" style="width: 100px; height: 100px;">
                                        <img src = "img/featur-2.jpg" class="img-fluid rounded" alt="">
                                    </div>
                                    <div>
                                        <h6 class="mb-2">Big Banana</h6>
                                        <div class="d-flex mb-2">
                                            <i class="fa fa-star text-secondary"></i>
                                            <i class="fa fa-star text-secondary"></i>
                                            <i class="fa fa-star text-secondary"></i>
                                            <i class="fa fa-star text-secondary"></i>
                                            <i class="fa fa-star"></i>
                                        </div>
                                        <div class="d-flex mb-2">
                                            <h5 class="fw-bold me-2">2.99 $</h5>
                                            <h5 class="text-danger text-decoration-line-through">4.11 $</h5>
                                        </div>
                                    </div>
                                </div>

        */
    }
}