using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.AddressDtos;
using Entities.Dtos.OrderDtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcUIApp.Models;
using Services.Contracts;

namespace MvcUIApp.Controllers
{
    [Authorize]
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
                UserAddresses = _manager.Address.GetByUserAddresses(User.Identity.Name)
            });
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout([FromForm] OrderDtoForInsertion orderDto)
        {
             if(_cart.Lines.Count() == 0)
                ModelState.AddModelError("", "Üzgünüm, Alış veriş sepetiniz boş");
            
            if(ModelState.IsValid)
            {
                orderDto.Lines = _cart.Lines.ToArray();
                string orderCode =  await _manager.Order.SaveOrder(orderDto);
                _cart.Clear();
                return RedirectToPage("/Complete", new {OrderCode = orderCode});
            }
            else
            {
                 return View("Checkout", new OrderViewModel(){
                    Order =  new(){Lines = _cart.Lines},
                    UserAddresses = _manager.Address.GetByUserAddresses(User.Identity.Name)
                 });
            }
        }
        

        public IActionResult AddAddress()
        {
            return PartialView("~/Views/Partials/_AddressAddFormModal.cshtml", new AddressDtoForInsertion());
        }
        public IActionResult EditAddress(int id)
        {
            AddressDtoForUpdate addressDto = _manager.Address.GetOneAddressDtoForUpdate(id); 
            return PartialView("~/Views/Partials/_AddressEditFormModal.cshtml", addressDto);
        }
        public IActionResult DeleteAddress(int id)
        {
              _manager.Address.DeleteOneAddress(id); 
            return View("Checkout");
        }
    }
}