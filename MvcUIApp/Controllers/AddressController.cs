using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.AddressDtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Services.Contracts;

namespace MvcUIApp.Controllers
{
    
    public class AddressController : Controller
    {
        private readonly IServiceManager _manager;

        public AddressController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAddress([FromForm] AddressDtoForInsertion addressDto)
        {
         
                _manager.Address.CreateUserAddToAddress(User.Identity.Name, addressDto);
                return RedirectToAction("Checkout", "Order");
            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAddress([FromForm] AddressDtoForUpdate addressDto)
        {
              
                return RedirectToAction("Checkout", "Order");           
        }
    }
}