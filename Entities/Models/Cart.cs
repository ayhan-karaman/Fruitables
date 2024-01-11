using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }

        public Cart()
        {
            Lines = new();
        }

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines.Where(x => x.Product.Id == product.Id).FirstOrDefault();
            if(line is null)
            {
                Lines.Add(new CartLine(){
                     Product = product,
                     Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void DecreaseQuantity(Product product, int quantity)
        {
            CartLine? line = Lines.Where(x => x.Product.Id == product.Id).FirstOrDefault();
            if(line is null)
            {
                throw new Exception("Ürün bulunamadı!");
            }
            else
            {
                  line.Quantity -= (line.Quantity - quantity) ;
            }
        }
        public virtual void RemoveItem(Product product)
        => Lines.RemoveAll(x => x.Product.Id == product.Id);

        public decimal ComputeTotalValue() => Lines.Sum(x => x.Product.UnitPrice * x.Quantity);
        public virtual void Clear() => Lines.Clear();
    
    
    }
}