using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace MvcUIApp.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } =  Enumerable.Empty<Product>();
        public Pagination Pagination { get; set; } = new();
        public int TotalCount  => Products.Count();
    }
}