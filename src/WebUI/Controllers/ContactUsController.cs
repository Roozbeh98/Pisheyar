using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.Contact.Commands.SendMessage;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ApiController
    {
        /// <summary>
        /// ارسال پیام تماس با ما
        /// </summary>
        /// <param name="command">اطلاعات تماس با ما</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<SendMessageVm> SendMessage(SendMessageCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}