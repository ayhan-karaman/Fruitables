using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.Common;
using Entities.Models.Identities;

namespace Entities.Models
{
    public class Address : BaseEntity
    {
        public int AppUserId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Line { get; set; }
        public int BuildingNumber { get; set; }
        public int HomeNumber { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public AppUser AppUser { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}