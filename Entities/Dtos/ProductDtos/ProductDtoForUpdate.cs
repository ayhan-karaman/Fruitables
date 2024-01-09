using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.ProductDtos
{
    public record ProductDtoForUpdate:ProductDto
    {
        public int Id { get; init; }
        public int CategoryId { get; init; }
    }
}