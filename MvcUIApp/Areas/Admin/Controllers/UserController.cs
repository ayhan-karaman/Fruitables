
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.IdentityDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcUIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }
        
        public IActionResult Index()
        {
            var users =  _manager.AppUser.GetAllAppUsers();
            return View(users);
        }

        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            var user = await _manager.AppUser.GetOneAppUserForUpdateAsync(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] AppUserDtoForUpdate appUserDto)
        {
            
            if (ModelState.IsValid)
            {
                await  _manager.AppUser.UpdateAppUserAsync(appUserDto);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}