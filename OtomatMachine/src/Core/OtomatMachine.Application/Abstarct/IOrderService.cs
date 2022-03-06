using OtomatMachine.Domain.DTOs.Orders;
using OtomatMachine.Domain.Entities;
using OtomatMachine.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Application.Abstarct
{
    public interface IOrderService
    {
        Task<Result<OrderDtoForResponse>> AddOrder(OrderDtoForAdd orderDtoForAdd);
        Task<Result<Order>> GetOrderById(int orderId);
    }
}
