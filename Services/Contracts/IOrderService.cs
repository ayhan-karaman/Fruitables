using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.OrderDtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneOrder(int id);
        void Complete(int id);
        Task<string> SaveOrder(OrderDtoForInsertion orderDto);
        int NumberOfInProcess { get; }
    }
}