using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.Tags.Queries.GetAllTags;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ApiController
    {
        /// <summary>
        /// دریافت 100 برچسب برتر
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<AllTagsVm>> GetAll()
        {
            return await Mediator.Send(new GetAllTagsQuery());
        }
    }
}