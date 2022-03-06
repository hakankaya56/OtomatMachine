using AutoMapper;
using OtomatMachine.Application.Abstarct;
using OtomatMachine.Domain.DTOs.Foods;
using OtomatMachine.Domain.Repositories.Abstract;
using OtomatMachine.Shared.Constants;
using OtomatMachine.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Application.Concrete
{
    public class FoodManager : IFoodService
    {
        private readonly IFoodRepository _foodReository;
        private readonly IMapper _mapper;

        public FoodManager(IFoodRepository foodReository, IMapper mapper)
        {
            _foodReository = foodReository;
            _mapper = mapper;
        }

        public async Task<Result<List<FoodDtoForList>>> GetFoods()
        {
            var foods = await _foodReository.GetListAsync();
            var foodDtoForList = _mapper.Map<List<FoodDtoForList>>(foods);
            return foods.Count > 0 
                ? Result<List<FoodDtoForList>>.Success(foodDtoForList) 
                : Result<List<FoodDtoForList>>.Fail(Messages.RecordNotFound);
        }
    }
}
