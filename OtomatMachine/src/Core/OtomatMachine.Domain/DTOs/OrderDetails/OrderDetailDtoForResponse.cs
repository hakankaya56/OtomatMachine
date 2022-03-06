using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.DTOs.OrderDetails
{
    public class OrderDetailDtoForResponse
    {
        public string FoodName { get; set; }
        public int FoodQuantity { get; set; }
        public decimal FoodUnitPrice { get; set; }
        public string DrinkName { get; set; }
        public int DrinkQuantity { get; set; }
        public decimal DrinkUnitPrice { get; set; }
    }
}
