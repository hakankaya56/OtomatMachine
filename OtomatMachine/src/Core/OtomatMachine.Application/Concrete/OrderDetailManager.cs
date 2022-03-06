using AutoMapper;
using OtomatMachine.Application.Abstarct;
using OtomatMachine.Domain.DTOs;
using OtomatMachine.Domain.DTOs.OrderDetails;
using OtomatMachine.Domain.Entities;
using OtomatMachine.Domain.Repositories.Abstract;
using OtomatMachine.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Application.Concrete
{
    public class OrderDetailManager:IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailManager(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<OrderDetailDtoForResponse>>> AddOrderDetails(List<OrderDetailDtoForAdd> orderDetailDtoForAdd)
        {
          var orderDetails =  _mapper.Map<List<OrderDetail>>(orderDetailDtoForAdd);
          var addedOrderDetails = await  _orderDetailRepository.AddRangeAsync(orderDetails);
            if (addedOrderDetails.Count > 0)
            {
                var orderDetailResponse = _mapper.Map<List<OrderDetailDtoForResponse>>(addedOrderDetails);
                return Result<List<OrderDetailDtoForResponse>>.Success(orderDetailResponse);
            }

            return Result<List<OrderDetailDtoForResponse>>.Fail();
        }
    }
}
