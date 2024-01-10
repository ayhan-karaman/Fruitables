using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.ProductDtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using AutoMapper;
using Entities.RequestParameters.Products;

namespace Services.Concrete
{
    public class ProductManager : IProductService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _manager.ProductRepository.CreateEntity(product);
            _manager.Save();
        }

        public IEnumerable<Product> GetAllProducts(bool tracking)
        {
            return _manager.ProductRepository.FindAll(tracking);
        }

        public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameter parameter)
        {
            return _manager.ProductRepository.GetAllProductsWithDetails(parameter);
        }

        public void UpdatOneProduct(ProductDtoForUpdate productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _manager.ProductRepository.UpdateEntity(product);
            _manager.Save();
        }
        public IEnumerable<Product> GetLatestProducts(int n, bool tracking)
        {
            return _manager.ProductRepository.FindAll(tracking)
            .OrderByDescending(x => x.CreatedAt)
            .Take(n);
        }
        private Product GetOneProduct(int id, bool tracking)
        {
            Product? product = _manager.ProductRepository.FindCondition(x => x.Id == id, tracking);
            if(product is null)
                throw new Exception("Product not found");
            return product;
        }

        public Product GetByIdOneProduct(int id, bool tracking)
        {
            return GetOneProduct(id, tracking);
        }
    }
}