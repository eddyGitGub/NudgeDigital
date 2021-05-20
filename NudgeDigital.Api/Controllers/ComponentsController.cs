using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Features.Components.Command;
using NudgeDigital.Application.Features.Components.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NudgeDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentsController : BaseController
    {

        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateComponentCommand command)
        {
            var res = await Mediator.Send(command);

            return Ok(res);
        }


        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<ComponentVM>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var res = await Mediator.Send(new GetAllComponentQuery());

            return Ok(res);
        }
    }
}
