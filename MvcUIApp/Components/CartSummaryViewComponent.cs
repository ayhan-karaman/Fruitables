using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MvcUIApp.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart _cart;

        public CartSummaryViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public string Invoke() => _cart.Lines.Count().ToString();
    }
}