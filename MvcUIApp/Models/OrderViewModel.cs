using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.AddressDtos;
using Entities.Models;

namespace MvcUIApp.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public AddressDtoForInsertion AddressDtoForInsertion { get; set; }
        public AddressDtoForUpdate AddressDtoForUpdate { get;  set; }
        public IEnumerable<Address> UserAddresses { get; set; }
    }
}