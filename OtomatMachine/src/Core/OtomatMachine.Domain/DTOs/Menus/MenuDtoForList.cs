using OtomatMachine.Domain.DTOs.Drinks;
using OtomatMachine.Domain.DTOs.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.DTOs.Menus
{
    public class MenuDtoForList
    {
        public List<FoodDtoForList> Foods { get; set; }
        public List<DrinkDtoForList> Drinks { get; set; }
    }
}
