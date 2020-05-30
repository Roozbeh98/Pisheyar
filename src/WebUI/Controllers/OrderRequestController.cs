using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.OrderRequests.Commands.AcceptOrderRequest;
using Pisheyar.Application.OrderRequests.Commands.AllowContractorToChatByClient;
using Pisheyar.Application.OrderRequests.Commands.CreateOrderRequest;
using Pisheyar.Application.OrderRequests.Queries.GetChatMessages;
using Pisheyar.Application.OrderRequests.Queries.GetChatRooms;
using Pisheyar.Application.OrderRequests.Queries.GetContractorOrderRequests;
using Pisheyar.Application.OrderRequests.Queries.GetOrderRequestAcceptanceStatus;
using Pisheyar.Application.OrderRequests.Queries.GetOrderRequestAccessStatus;
using Pisheyar.Application.OrderRequests.Queries.GetOrderRequestAllowingStatus;
using Pisheyar.Application.OrderRequests.Queries.GetOrderRequestFinishingStatus;
using Pisheyar.Application.OrderRequests.Queries.GetOrderRequestsForClient;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderRequestController : ApiController
    {
        /// <summary>
        /// افزودن درخواست سفارش جدید
        /// </summary>
        /// <param name="command">اطلاعات درخواست سفارش</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CreateOrderRequestVm>> Create(CreateOrderRequestCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تایید درخواست سفارش
        /// </summary>
        /// <param name="command">اطلاعات درخواست سفارش</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<AllowContractorToChatByClientVm>> AllowContractorToChatByClient(AllowContractorToChatByClientCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تایید درخواست سفارش
        /// </summary>
        /// <param name="command">اطلاعات درخواست سفارش</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<AcceptOrderRequestVm>> Accept(AcceptOrderRequestCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// دریافت درخواست سفارش های ثبت شده سرویس دهنده
        /// </summary>
        /// <param name="stateGuid">آیدی وضعیت درخواست</param>
        /// <param name="allowedOnly">درخواست های پذیرفته شده</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetContractorOrderRequestsVm>> GetContractorOrderRequests(Guid? stateGuid, bool allowedOnly)
        {
            return await Mediator.Send(new GetContractorOrderRequestsQuery() { StateGuid = stateGuid, AllowedOnly = allowedOnly });
        }

        /// <summary>
        /// دریافت درخواست سفارش ها جهت تایید توسط سرویس گیرنده
        /// </summary>
        /// <param name="orderGuid">آیدی سفارش</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetOrderRequestsForClientVm>> GetOrderRequestsForClient(Guid? orderGuid)
        {
            return await Mediator.Send(new GetOrderRequestsForClientQuery() { OrderGuid = orderGuid });
        }

        /// <summary>
        /// دریافت وضعیت پذیرفته شدن درخواست سفارش
        /// </summary>
        /// <param name="orderRequestGuid">آیدی درخواست سفارش</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetOrderRequestAllowingStatusVm>> GetAllowingStatus(Guid orderRequestGuid)
        {
            return await Mediator.Send(new GetOrderRequestAllowingStatusQuery() { OrderRequestGuid = orderRequestGuid });
        }

        /// <summary>
        /// دریافت وضعیت پذیرفته شدن درخواست سفارش
        /// </summary>
        /// <param name="orderRequestGuid">آیدی درخواست سفارش</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetOrderRequestAcceptanceStatusVm>> GetAcceptanceStatus(Guid orderRequestGuid)
        {
            return await Mediator.Send(new GetOrderRequestAcceptanceStatusQuery() { OrderRequestGuid = orderRequestGuid });
        }

        /// <summary>
        /// دریافت وضعیت اتمام درخواست سفارش
        /// </summary>
        /// <param name="orderRequestGuid">آیدی درخواست سفارش</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetOrderRequestFinishingStatusVm>> GetFinishingStatus(Guid orderRequestGuid)
        {
            return await Mediator.Send(new GetOrderRequestFinishingStatusQuery() { OrderRequestGuid = orderRequestGuid });
        }

        /// <summary>
        /// دریافت وضعیت دسترسی درخواست سفارش
        /// </summary>
        /// <param name="orderRequestGuid">آیدی درخواست سفارش</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetOrderRequestAccessStatusVm>> GetAccessStatus(Guid orderRequestGuid)
        {
            return await Mediator.Send(new GetOrderRequestAccessStatusQuery() { OrderRequestGuid = orderRequestGuid });
        }

        /// <summary>
        /// دریافت لیست درخواست های پذیرفته شده توسط سرویس گیرنده
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetChatRoomsVm>> GetChatRooms()
        {
            return await Mediator.Send(new GetChatRoomsQuery());
        }

        /// <summary>
        /// دریافت تاریخچه پیام ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetChatMessagesVm>> GetChatMessages(Guid orderRequestGuid)
        {
            return await Mediator.Send(new GetChatMessagesQuery() { OrderRequestGuid = orderRequestGuid });
        }
    }
}