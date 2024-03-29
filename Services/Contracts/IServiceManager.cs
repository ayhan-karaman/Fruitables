using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        ICategoryService Category { get; }
        IProductService Product { get; }
        IOrderService Order { get; }
        IAppUserService AppUser { get; }
        IAddressService Address { get; }
    }
}