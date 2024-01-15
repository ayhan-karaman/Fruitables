using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.IdentityDtos;
using Entities.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcUIApp.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IServiceManager _serviceManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IServiceManager serviceManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _serviceManager = serviceManager;
        }

        public IActionResult Login([FromQuery(Name = "returnUrl")] string returnUrl = "/")
        {
            return View(new LoginDto(){
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginDto model)
        {
            if(ModelState.IsValid)
            {
                AppUser? user = await _userManager.FindByEmailAsync(model.Email);
                if(user is not null)
                {
                    await _signInManager.SignOutAsync();
                    if((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        return Redirect(model.ReturnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("", "Invalid user email or password");
            }
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterDto registeDto)
        {
            if(ModelState.IsValid)
            {
               var result =  await _serviceManager.AppUser.RegisterAppUserAsync(registeDto);
               if(result.Succeeded)
               {
                    return RedirectToAction("Login");
               }

            }
            return View();
        }

        public async Task<IActionResult> Logout([FromQuery(Name="ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }
    }
}