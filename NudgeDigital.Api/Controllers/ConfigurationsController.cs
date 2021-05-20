using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Features.Configurations.Command;
using NudgeDigital.Application.Features.Configurations.Queries;
using NudgeDigital.Application.Features.Configurations.Query;

namespace NudgeDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : BaseController
    {
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateConfigurationCommand command)
        {
            var res = await Mediator.Send(command);

            return Ok(res);
        }

        
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<ConfigurationVM>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var res = await Mediator.Send(new GetConfigurationQuery());

            return Ok(res);
        }

     

    }
}
