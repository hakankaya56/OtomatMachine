using OtomatMachine.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.Entities
{
    public class Order : EntityBase
    {
        public short PaymentType { get; set; }
        public bool IsPaperMoney { get; set; }
        public bool IsContact { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
