using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.RequestParameters.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcUIApp.Models;
using Services.Contracts;

namespace MvcUIApp.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameter parameter)
        {
            ViewBag.CategoryId = parameter.CategoryId is null ? null : parameter.CategoryId;
            var products = _manager.Product.GetAllProductsWithDetails(parameter);
            Pagination pagination = new()
            {
                CurrentPage = parameter.PageNumber,
                ItemsPerPage = parameter.PageSize,
                TotalItems = _manager.Product.GetAllProducts(false).Count()
            };
            ProductListViewModel viewModel = new()
            {
                Products = products,
                Pagination = pagination
            };
            return View(viewModel);
        }
    }
}