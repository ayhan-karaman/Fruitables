using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.ProductDtos;
using Entities.Models;
using Entities.RequestParameters.Products;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool tracking);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameter parameter);
        IEnumerable<Product> GetLatestProducts(int n, bool tracking);
        void CreateOneProduct(ProductDtoForInsertion productDto);
        void UpdatOneProduct(ProductDtoForUpdate productDto);
        
    }
}