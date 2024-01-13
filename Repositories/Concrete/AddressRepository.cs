using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Models.Identities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateUserAddToAddress(AppUser user, Address address)
        {
            address.AppUser = user;
            CreateEntity(address);
        }

        public IEnumerable<Address> GetByUserNameAddresses(string userName)
        {
           return _context.Addresses.Include(x => x.AppUser).Where(x => x.AppUser.UserName == userName);
        }
    }
}