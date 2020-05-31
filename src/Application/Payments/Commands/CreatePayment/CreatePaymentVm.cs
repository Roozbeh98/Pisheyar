using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Payments.Commands.CreatePayment
{
    public class CreatePaymentVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public string PaymentUrl { get; set; }
    }
}
