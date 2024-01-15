using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.AddressDtos
{
    public record AddressDtoForUpdate:AddressDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}