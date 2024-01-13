using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.AddressDtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcUIApp.Models;
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
            return View(new OrderViewModel(){
                Order =  new(){Lines = _cart.Lines},
                UserAddresses = _manager.Address.GetByUserAddresses(User.Identity.Name),
                AddressDtoForInsertion = new AddressDtoForInsertion()
               
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