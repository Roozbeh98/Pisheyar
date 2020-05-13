using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.Clients.Commands.CreateOrder;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ApiController
    {
        /// <summary>
        /// افزودن سفارش جدید
        /// </summary>
        /// <param name="command">اطلاعات سفارش</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CreateOrderVm>> CreateOrder(CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}