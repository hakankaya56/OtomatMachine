using OtomatMachine.Domain.Entities;
using OtomatMachine.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.Repositories.Abstract
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<Order> GetOrderByIdWithDetail(int orderId);
    }
}
