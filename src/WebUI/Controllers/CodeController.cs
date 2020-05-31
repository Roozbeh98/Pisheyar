using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.Codes.Queries.GetCodesByCodeGroupGuid;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ApiController
    {
        /// <summary>
        /// دریافت مقادیر ثابت
        /// </summary>
        /// <param name="guid">آیدی</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetCodesByCodeGroupGuidVm>> GetCodesByCodeGroupGuid(Guid guid)
        {
            return await Mediator.Send(new GetCodesByCodeGroupGuidQuery() { CodeGroupGuid = guid });
        }
    }
}
