using Pisheyar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pisheyar.Application.Common.Interfaces
{
    public interface ISmsService
    {
        Task<object> SendServiceable(SmsTemplate template, string receptor, string token = "", string token2 = "", string token3 = "", string token10 = "", string token20 = "");

        Task<object> SendAdvertising(string sender, string receptor, string message);
    }
}
