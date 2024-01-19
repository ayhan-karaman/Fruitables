using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts;

namespace MvcUIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var categories = _manager.Category.GetAllCategories(false);
            return View(categories);
        }

        public IActionResult CreateOneCategory()
        {
            CategoryDtoForInsertion categoryDto = new CategoryDtoForInsertion();
            return PartialView("~/Areas/Admin/Views/Partials/Categories/CreateCategoryModal.cshtml", categoryDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOneCategory([FromForm] CategoryDtoForInsertion categoryDto)
        {
            if (ModelState.IsValid)
            {
                _manager.Category.CreateOneCategory(categoryDto);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        public IActionResult UpdateOneCategory([FromRoute] int id)
        {
            CategoryDtoForUpdate categoryDto = _manager.Category.GetCategoryDtoForUpdate(id);
            return PartialView("~/Areas/Admin/Views/Partials/Categories/UpdateCategoryModal.cshtml", categoryDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOneCategory([FromForm] CategoryDtoForUpdate categoryDto)
        {
            if (ModelState.IsValid)
            {
                _manager.Category.UpdateOneCategory(categoryDto);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOneCategory([FromForm] int id)
        {
            _manager.Category.DeleteOneCategory(id);
            return RedirectToAction("Index");
        }

        
    }
}