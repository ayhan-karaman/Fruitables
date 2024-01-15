using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Models.Identities;

namespace Entities.Dtos.OrderDtos
{
    public record OrderDto
    {
        
        public IEnumerable<CartLine>? Lines { get; set; } = new List<CartLine>();
        public string UserName { get; init; }
        public int AddressId { get; init; }
        public string? Notes { get; init; }
        public bool Shipped { get; set; } = false;
        public DateTime OrderedAt { get; set; } = DateTime.UtcNow;
    }
}