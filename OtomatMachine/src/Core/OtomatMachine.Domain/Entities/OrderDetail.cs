using OtomatMachine.Domain.Entites;
using OtomatMachine.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.Entities
{
    public class OrderDetail:EntityBase
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Food")]
        public int FoodId { get; set; }
        [ForeignKey("Drink")]
        public int DrinkId { get; set; }    
        public int FoodQuantity { get; set; }    
        public int DrinkQuantity { get; set; }    
        public decimal FoodTotalPrice { get; set; }    
        public decimal DrinkTotalPrice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Food Food { get; set; }
        public virtual Drink Drink { get; set; }
    }
}
