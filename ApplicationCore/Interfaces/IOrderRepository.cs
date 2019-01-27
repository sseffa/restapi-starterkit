using ApplicationCore.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<Order> GetByIdWithItemsAsync(int id);
    }
}
