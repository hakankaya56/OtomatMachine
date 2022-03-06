using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.DTOs
{
    public class OrderDetailDtoForAdd
    {
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public int DrinkId { get; set; }
        public int FoodQuantity { get; set; }
        public int DrinkQuantity { get; set; }
        public decimal FoodTotalPrice { get; set; }
        public decimal FoodUnitPrice { get; set; }
        public decimal DrinkTotalPrice { get; set; }
        public decimal DrinkUnitPrice { get; set; }
    }
}
