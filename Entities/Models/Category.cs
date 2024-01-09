using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.Common;

namespace Entities.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}