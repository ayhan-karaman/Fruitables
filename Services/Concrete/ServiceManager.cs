using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Contracts;

namespace Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IAppUserService _appUserService;
        private readonly IAddressService _addressService;

        public ServiceManager(ICategoryService categoryService, IProductService productService, IOrderService orderService, IAppUserService appUserService, IAddressService addressService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _appUserService = appUserService;
            _addressService = addressService;
        }

        public ICategoryService Category => _categoryService;

        public IProductService Product => _productService;

        public IOrderService Order => _orderService;

        public IAppUserService AppUser => _appUserService;

        public IAddressService Address => _addressService;
    }
}