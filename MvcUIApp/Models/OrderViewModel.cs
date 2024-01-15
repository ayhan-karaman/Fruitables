using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.AddressDtos;
using Entities.Dtos.OrderDtos;
using Entities.Models;

namespace MvcUIApp.Models
{
    public class OrderViewModel
    {
        public OrderDtoForInsertion Order { get; set; }
        public IEnumerable<Address> UserAddresses { get; set; }
    }
}