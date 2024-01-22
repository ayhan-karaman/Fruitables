using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos.OrderDtos;
using Entities.Models;
using Entities.Models.Identities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _manager;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public OrderManager(IRepositoryManager manager, IMapper mapper, IAppUserService appUserService)
        {
            _manager = manager;
            _mapper = mapper;
            _appUserService = appUserService;
        }

        public IQueryable<Order> Orders => _manager.OrderRepository.Orders
        .Include(x => x.AppUser).Include(x => x.Address);

        public int NumberOfInProcess => _manager.OrderRepository.NumberOfInProcess;

        public void Complete(int id)
        {
            _manager.OrderRepository.Complete(id);
            _manager.Save();
        }

        public Order? GetOneOrder(int id)
        {
         
           return _manager.OrderRepository.GetOneOrder(id);
        }
       

        public async Task<string> SaveOrder(OrderDtoForInsertion orderDto)
        {
        
            Order order = _mapper.Map<Order>(orderDto);
            AppUser appUser = await _appUserService.GetOneByNameAppUserAsync(orderDto.UserName);
         
            order.AppUser = appUser;
            order.OrderCode = CreatedGuidCode();
            _manager.OrderRepository.SaveOrder(order);
            _manager.Save();
            return order.OrderCode;
        }

        private string CreatedGuidCode()
        {
            string code = Guid.NewGuid().ToString();
            code = Regex.Replace(code, "[^a-zA-Z0-9]", "");
            return code;
        }
    }
}