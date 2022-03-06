using AutoMapper;
using OtomatMachine.Domain.DTOs;
using OtomatMachine.Domain.DTOs.Drinks;
using OtomatMachine.Domain.DTOs.Foods;
using OtomatMachine.Domain.DTOs.OrderDetails;
using OtomatMachine.Domain.DTOs.Orders;
using OtomatMachine.Domain.Entites;
using OtomatMachine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region DrinkDtos
            CreateMap<Drink, DrinkDtoForList>().ReverseMap();
            #endregion

            #region FoodDtos
            CreateMap<Food, FoodDtoForList>().ReverseMap();
            #endregion

            #region OrderDtos
            CreateMap<OrderDtoForAdd, Order>().ReverseMap();
            CreateMap<Order, OrderDtoForResponse>().ForMember(src => src.PaymentTypeId, dest => dest.MapFrom(opt => opt.PaymentType));
            #endregion

            #region OrderDetailDtos
            CreateMap<OrderDetailDtoForAdd, OrderDetail>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDtoForResponse>()
                .ForMember(src => src.FoodName, dest => dest.MapFrom(opt => opt.Food.Name))
                .ForMember(src => src.FoodUnitPrice, dest => dest.MapFrom(opt => opt.Food.Price))
                .ForMember(src => src.DrinkName, dest => dest.MapFrom(opt => opt.Drink.Name))
                .ForMember(src => src.DrinkUnitPrice, dest => dest.MapFrom(opt => opt.Drink.Price));
            #endregion
        }
    }
}
