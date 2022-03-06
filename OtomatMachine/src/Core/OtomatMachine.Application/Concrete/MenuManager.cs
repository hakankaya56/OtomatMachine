using OtomatMachine.Application.Abstarct;
using OtomatMachine.Domain.DTOs.Menus;
using OtomatMachine.Shared.Constants;
using OtomatMachine.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Application.Concrete
{
    public class MenuManager : IMenuService
    {
        private readonly IDrinkService _drinkService;
        private readonly IFoodService _foodService;
        public MenuManager(IDrinkService drinkService, IFoodService foodService)
        {
            _drinkService = drinkService;
            _foodService = foodService;
        }

        public async Task<Result<MenuDtoForList>> Menus()
        {
            var drinksResult = await _drinkService.GetDrinks();
            var foodsResult = await _foodService.GetFoods();
            if (!drinksResult.IsSuccess || !foodsResult.IsSuccess)
            {
                return Result<MenuDtoForList>.Fail(Messages.RecordNotFound);
            }
            var menuDtoForList = new MenuDtoForList
            {
                Foods = foodsResult.Data,
                Drinks = drinksResult.Data
            };
            return Result<MenuDtoForList>.Success(menuDtoForList);
        }
    }
}
