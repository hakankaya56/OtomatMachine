using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.DTOs.Drinks
{
   public class DrinkDtoForList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsHot { get; set; }
    }
}
