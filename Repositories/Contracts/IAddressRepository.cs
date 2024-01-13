using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Models.Identities;

namespace Repositories.Contracts
{
    public interface IAddressRepository:IRepositoryBase<Address>
    {
        IEnumerable<Address> GetByUserNameAddresses(string userName);
        void CreateUserAddToAddress(AppUser user, Address address);
    }
}