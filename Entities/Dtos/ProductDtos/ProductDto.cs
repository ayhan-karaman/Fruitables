using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.ProductDtos
{
    public record ProductDto
    {
       
        public string Name { get; init; }
        
        public string? ImageUrl { get; set; }
        public decimal UnitPrice { get; init; }
        public bool? ShowCase { get; init; }
        public decimal UnitsInStock { get; init; }
    }
}