using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.AddressDtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Services.Contracts;

namespace MvcUIApp.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IServiceManager _manager;

        public AddressController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress([FromForm] AddressDtoForInsertion addressDto)
        {
             if(ModelState.IsValid)
             {
                await _manager.Address.CreateUserAddToAddress(User.Identity.Name, addressDto);
                return RedirectToAction("Checkout", "Order");
             }
             return RedirectToAction("Checkout", "Order");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAddress([FromForm] AddressDtoForUpdate addressDto)
        {
            if(ModelState.IsValid)
            {
                await _manager.Address.UpdateUserToAddress(addressDto);
                return RedirectToAction("Checkout", "Order");           
            }
            return RedirectToAction("Checkout", "Order");
        }

    }
}