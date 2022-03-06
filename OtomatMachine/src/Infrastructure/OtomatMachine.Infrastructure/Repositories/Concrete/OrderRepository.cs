using Microsoft.EntityFrameworkCore;
using OtomatMachine.Domain.Entities;
using OtomatMachine.Domain.Repositories.Abstract;
using OtomatMachine.Infrastructure.DataContext;
using OtomatMachine.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Infrastructure.Repositories.Concrete
{
    public class OrderRepository:RepositoryBase<Order>, IOrderRepository
    {
        private readonly OtomatMachineContext _otomatMachineContext;
        public OrderRepository(OtomatMachineContext otomatMachineContext):base(otomatMachineContext)
        {
            _otomatMachineContext = otomatMachineContext;
        }

        public async Task<Order> GetOrderByIdWithDetail(int orderId)
        {
          var orderResult =  _otomatMachineContext.Orders.
                Include(order => order.OrderDetails).
                ThenInclude(orderDetail => orderDetail.Food).
                Include(order => order.OrderDetails).
                ThenInclude(orderDetail => orderDetail.Drink).
                FirstOrDefaultAsync(order => order.Id == orderId);
            return await orderResult;
        }
    }
}
