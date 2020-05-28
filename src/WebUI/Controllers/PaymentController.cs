using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.Payments.Commands.CreatePayment;
using Pisheyar.Application.Payments.Commands.VerifyPayment;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command">اطلاعات درخواست پرداخت</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CreatePaymentVm>> Create(CreatePaymentCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentGuid">آیدی پرداخت</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult> OnlinePayment(Guid paymentGuid)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                VerifyPaymentVm res = await Mediator.Send(new VerifyPaymentCommand() { PaymentGuid = paymentGuid, Authority = HttpContext.Request.Query["Authority"].ToString() });

                if (res.State == 1)
                {
                    return Redirect("https://tavanito.com/services/?categories[]=77");
                }
            }

            return Redirect("https://tavanito.com/services/?categories[]=77");
        }
    }
}
