using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcUIApp.Components
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoryListViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _manager.Category.GetAllCategories(false);
            return View(categories);
        }
    }
}