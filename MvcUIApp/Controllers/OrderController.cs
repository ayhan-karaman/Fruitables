using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts;

namespace MvcUIApp.Controllers
{
    
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly Cart _cart;

        public OrderController(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            _cart = cart;
        }

        public IActionResult Checkout()
        {
            return View(new Order(){
                 Lines = _cart.Lines
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {
             if(_cart.Lines.Count() == 0)
                ModelState.AddModelError("", "Üzgünüm, Alış veriş sepetiniz boş");
            
            if(ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _manager.Order.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new {OrderId = order.Id});
            }
            else
            {
                 return View();
            }
        }
    }
}