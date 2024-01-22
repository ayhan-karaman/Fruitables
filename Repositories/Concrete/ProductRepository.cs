using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestParameters.Products;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories.Concrete
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameter parameter)
        {
            return _context.Products
            .FilteredByCategoryId(parameter.CategoryId)
            .FilteredByMinAndMaxPrice(parameter.MinPrice, parameter.MaxPrice, parameter.IsValidPrice)
            .FilteredBySearchTerm(parameter.SearchTerm)
            .ToPaginate(parameter.PageNumber, parameter.PageSize)
            .ToList();
        }

        public IEnumerable<Product> GetShowcaseProducts(bool tracking)
         => FindAll(tracking).Where(x => x.ShowCase.Equals(true)).ToList();
    }
}