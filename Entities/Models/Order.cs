using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.Common;

namespace Entities.Models
{
    public class Order : BaseEntity
    {
        public IEnumerable<CartLine>? Lines { get; set; } = new List<CartLine>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string? Notes { get; set; }
        public bool Shipped { get; set; }
    }
}