using Pisheyar.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZarinpalSandbox;
using ZarinpalSandbox.Models;

namespace Pisheyar.Infrastructure.Services
{
    public class ZarinPalService : IZarinPalService
    {
        public async Task<string> CreatePaymentRequest(Guid paymentGuid, int cost, string email, string mobile)
        {
            var payment = new Payment(cost);
            var res = await payment.PaymentRequest($"پرداخت شماره {paymentGuid}", "http://185.94.97.164/api/Payment/OnlinePayment/" + paymentGuid, email, mobile);
            return res.Status == 100 ? "https://sandbox.zarinpal.com/pg/StartPay/" + res.Authority : null;
        }

        public async Task<(bool, long)> VerifyPayment(int cost, string authority)
        {
            var payment = new Payment(cost);
            PaymentVerificationResponse res = await payment.Verification(authority);
            return (res.Status == 100, res.RefId);
        }
    }
}
