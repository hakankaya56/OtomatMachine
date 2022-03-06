using AutoMapper;
using OtomatMachine.Application.Abstarct;
using OtomatMachine.Domain.DTOs.Drinks;
using OtomatMachine.Domain.Entites;
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
    public class DrinkManager : IDrinkService
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly IMapper _mapper;

        public DrinkManager(IDrinkRepository drinkRepository, IMapper mapper)
        {
            _drinkRepository = drinkRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<DrinkDtoForList>>> GetDrinks()
        {
            var drinks = await _drinkRepository.GetListAsync();
            var drinkDtoForList = _mapper.Map<List<DrinkDtoForList>>(drinks);
            return drinks.Count > 0
                ? Result<List<DrinkDtoForList>>.Success(drinkDtoForList)
                : Result<List<DrinkDtoForList>>.Fail(Messages.RecordNotFound);
        }
    }
}
