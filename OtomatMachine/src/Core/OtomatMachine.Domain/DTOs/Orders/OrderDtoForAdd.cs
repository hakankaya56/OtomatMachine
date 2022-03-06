using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.DTOs.Orders
{
    public class OrderDtoForAdd
    {
        public short PaymentType  { get; set; }
        public bool IsPaperMoney { get; set; }
        public bool IsContact { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }

        public List<OrderDetailDtoForAdd> OrderDetailDtoForAdds { get; set; }
    }
}
