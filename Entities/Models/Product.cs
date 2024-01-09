using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.Common;

namespace Entities.Models
{
    public class Product:BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public bool ShowCase { get; set; }
        public decimal UnitsInStock { get; set; }
        public Category? Category { get; set; }
    }
}