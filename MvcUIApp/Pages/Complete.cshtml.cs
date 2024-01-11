using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MvcUIApp.Pages
{
    public class Complete : PageModel
    {
        private readonly ILogger<Complete> _logger;

        public Complete(ILogger<Complete> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}