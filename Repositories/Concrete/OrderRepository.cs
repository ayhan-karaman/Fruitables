using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders
        .Include(x => x.Lines)
        .ThenInclude(x => x.Product)
        .OrderBy(x => x.Shipped)
        .ThenByDescending(x => x.Id);


        public int NumberOfInProcess => _context.Orders.Count(x => x.Shipped.Equals(false));

        public void Complete(int id)
        {
            Order order = FindCondition(x => x.Id == id, true);
            if(order is null)
                throw new Exception("Order could not found!");
            order.Shipped = true;
        }

        public Order? GetOneOrder(int id)
        => FindCondition(x => x.Id == id, false);

        

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if(order.Id == 0)
             _context.Orders.Add(order);
        }
    }
}