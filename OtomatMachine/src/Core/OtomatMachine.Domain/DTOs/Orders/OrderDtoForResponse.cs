using OtomatMachine.Domain.DTOs.OrderDetails;
using OtomatMachine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.DTOs.Orders
{
    public class OrderDtoForResponse
    {
        public decimal PaidAmount { get; set; }
        public decimal RemainderOfMoney { get; set; }
        public short PaymentTypeId { get; set; }
        public string PaymentType =>
            PaymentTypeId == (short)EPaymentTypes.Cash ? "Nakit"
            : PaymentTypeId == (short)EPaymentTypes.CreditCart ? "Kredi Kartı"
            : "";

        public List<OrderDetailDtoForResponse> OrderDetailsForResponse { get; set; }
    }
}
