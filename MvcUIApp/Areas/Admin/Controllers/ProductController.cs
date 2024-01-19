using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.ProductDtos;
using Entities.Models;
using Entities.RequestParameters.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MvcUIApp.Infrastructure.UploadHelpers;
using MvcUIApp.Models;
using Services.Contracts;

namespace MvcUIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameter parameter)
        {
            IEnumerable<Product>  products = _manager.Product.GetAllProductsWithDetails(parameter);
            Pagination pagination = new Pagination()
            {
                CurrentPage = parameter.PageNumber,
                ItemsPerPage = parameter.PageSize,
                TotalItems = _manager.Product.GetAllProducts(false).Count()
            };
            ProductListViewModel viewModel = new ProductListViewModel()
            {
                 Pagination = pagination,
                 Products = products
            };
            return View(viewModel);
        }
        
        public IActionResult CreateOneProduct()
        {
            ProductDtoForInsertion productDto = new ProductDtoForInsertion();
            ViewBag.Categories = GetCategoriesSelectList();
            return PartialView("~/Areas/Admin/Views/Partials/Products/CreateProductModal.cshtml", productDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOneProduct([FromForm] ProductDtoForInsertion productDto, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                productDto.ImageUrl = await FileHelper.Upload(file, "products");
                _manager.Product.CreateOneProduct(productDto);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateOneProduct(int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var product = _manager.Product.GetOneProductForUpdate(id);
            return PartialView("~/Areas/Admin/Views/Partials/Products/UpdateProductModal.cshtml", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOneProduct([FromForm]ProductDtoForUpdate productDto, IFormFile file)
        {
            
            if(ModelState.IsValid)
            {
                productDto.ImageUrl =  await FileHelper.UpdateFile(file, "products", productDto.ImageUrl);
                _manager.Product.UpdatOneProduct(productDto);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOneProduct([FromForm]int id, string returnUrl, string imageUrl)
        {
            _manager.Product.DeleteOneProduct(id);
            FileHelper.DeleteFile(imageUrl);
            return Redirect(returnUrl ?? "/admin/product");
        }
        private SelectList GetCategoriesSelectList()
         {
            var categories =  _manager.Category.GetAllCategories(false);
            return new SelectList(categories, "Id", "Name");
         }
    }
}