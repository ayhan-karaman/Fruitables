using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.IdentityDtos;
using Entities.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MvcUIApp.Controllers
{
    public class AuthController:Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login([FromQuery(Name = "returnUrl")] string returnUrl = "/")
        {
            return View(new LoginDto(){
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
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

        public async Task<IActionResult> Logout([FromQuery(Name = "returnUrl")] string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl ?? "/");
        }
    }
}