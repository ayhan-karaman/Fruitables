using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Entities.Models;
using MvcUIApp.Infrastructure.Extensions;

namespace MvcUIApp.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }
        internal static Cart GetCart(IServiceProvider provider)
        {
            ISession? session = provider.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson<SessionCart>("cart", this);
        }
        public override void DecreaseQuantity(Product product, int quantity)
        {
            base.DecreaseQuantity(product, quantity);
            Session?.SetJson<SessionCart>("cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }
        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
            Session?.SetJson<SessionCart>("cart", this);
        }
    }
}