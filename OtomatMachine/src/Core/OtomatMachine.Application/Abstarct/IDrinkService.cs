using OtomatMachine.Domain.DTOs.Drinks;
using OtomatMachine.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Application.Abstarct
{
    public interface IDrinkService
    {
      Task<Result<List<DrinkDtoForList>>> GetDrinks();
    }
}
