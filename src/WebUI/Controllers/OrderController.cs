using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.Orders.Commands.CreateOrder;
using Pisheyar.Application.Orders.Commands.FinishOrder;
using Pisheyar.Application.Orders.Queries.GetClientOrders;
using Pisheyar.Application.Orders.Queries.GetOrdersForContractor;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiController
    {
        /// <summary>
        /// افزودن سفارش جدید
        /// </summary>
        /// <param name="command">اطلاعات سفارش</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CreateOrderVm>> Create(CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// اتمام سفارش
        /// </summary>
        /// <param name="command">اطلاعات سفارش</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<FinishOrderVm>> Finish(FinishOrderCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// دریافت سفارش ها جهت انجام توسط سرویس دهنده
        /// </summary>
        /// <param name="categoryGuid">آیدی دسته بندی</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetOrdersForContractorVm>> GetOrdersForContractor(Guid? categoryGuid)
        {
            return await Mediator.Send(new GetOrdersForContractorQuery() { CategoryGuid = categoryGuid });
        }

        /// <summary>
        /// دریافت سفارش های ثبت شده سرویس گیرنده
        /// </summary>
        /// <param name="stateGuid">آیدی وضعیت سفارش</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetClientOrdersVm>> GetClientOrders(Guid? stateGuid)
        {
            return await Mediator.Send(new GetClientOrdersQuery() { StateGuid = stateGuid });
        }
    }
}