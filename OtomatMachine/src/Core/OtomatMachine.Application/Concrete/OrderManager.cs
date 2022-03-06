using AutoMapper;
using OtomatMachine.Application.Abstarct;
using OtomatMachine.Domain.DTOs.OrderDetails;
using OtomatMachine.Domain.DTOs.Orders;
using OtomatMachine.Domain.Entities;
using OtomatMachine.Domain.Repositories.Abstract;
using OtomatMachine.Domain.Repositories.Base;
using OtomatMachine.Shared.Constants;
using OtomatMachine.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Application.Concrete
{
    public class OrderManager : IOrderService
    {
        #region Constructur
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderManager(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper, IOrderDetailService orderDetailService)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderDetailService = orderDetailService;
        }
        #endregion
        public async Task<Result<OrderDtoForResponse>> AddOrder(OrderDtoForAdd orderDtoForAdd)
        {
            _unitOfWork.Begin();
            var order = _mapper.Map<Order>(orderDtoForAdd);
            var addedOrder = await _orderRepository.AddAsync(order);
            if (!Equals(addedOrder, null))
            {

                foreach (var orderDetailDto in orderDtoForAdd.OrderDetailDtoForAdds)
                {
                    orderDetailDto.OrderId = addedOrder.Id;
                    orderDetailDto.FoodTotalPrice = orderDetailDto.FoodUnitPrice * orderDetailDto.FoodQuantity;
                    orderDetailDto.DrinkTotalPrice = orderDetailDto.DrinkUnitPrice * orderDetailDto.DrinkQuantity;
                }
                var addedOrderDetail = await _orderDetailService.AddOrderDetails(orderDetailDtoForAdd: orderDtoForAdd.OrderDetailDtoForAdds);

                var orderResult = await this.GetOrderById(addedOrder.Id);
                if (orderResult.IsSuccess)
                {
                    var orderResponse = _mapper.Map<OrderDtoForResponse>(orderResult.Data);
                    orderResponse.RemainderOfMoney = addedOrder.PaidAmount - addedOrder.TotalAmount;
                    var orderDetailResponse = _mapper.Map<List<OrderDetailDtoForResponse>>(orderResult.Data.OrderDetails);
                    orderResponse.OrderDetailsForResponse = orderDetailResponse;
                    _unitOfWork.Commit();
                    return Result<OrderDtoForResponse>.Success(orderResponse);
                }
            }
            _unitOfWork.RollBack();
            return Result<OrderDtoForResponse>.Fail();
        }

        public async Task<Result<Order>> GetOrderById(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdWithDetail(orderId);
            return !Equals(order, null)
                 ? Result<Order>.Success(order)
                 : Result<Order>.Fail(Messages.RecordNotFound);
        }
    }
}
