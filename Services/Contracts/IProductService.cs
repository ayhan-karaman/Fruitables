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
        Product GetByIdOneProduct(int id, bool tracking);
        IEnumerable<Product> GetLatestProducts(int n, bool tracking);
        ProductDtoForUpdate GetOneProductForUpdate(int id);
        void CreateOneProduct(ProductDtoForInsertion productDto);
        void UpdatOneProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
        
    }
}