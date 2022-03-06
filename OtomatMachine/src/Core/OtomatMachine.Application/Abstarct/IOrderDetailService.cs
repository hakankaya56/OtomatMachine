using OtomatMachine.Domain.DTOs;
using OtomatMachine.Domain.DTOs.OrderDetails;
using OtomatMachine.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Application.Abstarct
{
    public interface IOrderDetailService
    {
        Task<Result<List<OrderDetailDtoForResponse>>> AddOrderDetails(List<OrderDetailDtoForAdd> orderDetailDtoForAdd);
    }
}
