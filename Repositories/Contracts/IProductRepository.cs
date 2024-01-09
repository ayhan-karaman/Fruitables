using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestParameters.Products;

namespace Repositories.Contracts
{
    public interface IProductRepository:IRepositoryBase<Product>
    {
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameter parameter);
    }
}