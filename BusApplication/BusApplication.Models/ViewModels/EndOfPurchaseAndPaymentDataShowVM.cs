using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class EndOfPurchaseAndPaymentDataShowVM
    {
        public BankAccount BankAccount { get; set; }
        public float TicketsValue { get; set; }
        public int PaymentId { get; set; }
    }
}
