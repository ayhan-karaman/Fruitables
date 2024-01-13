using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAddressRepository _addressRepository;

        public RepositoryManager(RepositoryContext context, IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, IAddressRepository addressRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
        }

        public IProductRepository ProductRepository => _productRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public IOrderRepository OrderRepository => _orderRepository;

        public IAddressRepository AddressRepository => _addressRepository;

        public void Save()
        => _context.SaveChanges();
    }
}