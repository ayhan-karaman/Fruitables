using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts;

namespace MvcUIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var orders =   _manager.Order.Orders;
            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Complete([FromForm] int id)
        {
            _manager.Order.Complete(id);
            return RedirectToAction("Index");
        }
    }
}