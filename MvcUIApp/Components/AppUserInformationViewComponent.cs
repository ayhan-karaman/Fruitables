using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcUIApp.Components
{
    public class AppUserInformationViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public AppUserInformationViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke(string userName)
        {
            var user = _manager.AppUser.GetAppUserDtoForInformation(userName);
            return View(user);
        }
    }
}