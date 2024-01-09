using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.ProductDtos
{
    public record ProductDtoForInsertion:ProductDto
    {
         public int CategoryId { get; init; }
    }
}