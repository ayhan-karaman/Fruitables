using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.AddressDtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IAddressService
    {
        Task CreateUserAddToAddress(string userName, AddressDtoForInsertion addressDto);
        IEnumerable<Address> GetByUserAddresses(string userName);
    }
}