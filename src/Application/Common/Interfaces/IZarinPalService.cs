using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pisheyar.Application.Common.Interfaces
{
    public interface IZarinPalService
    {
        Task<string> CreatePaymentRequest(Guid paymentGuid, int cost, string email, string mobile);

        Task<(bool, long)> VerifyPayment(int cost, string authority);
    }
}
