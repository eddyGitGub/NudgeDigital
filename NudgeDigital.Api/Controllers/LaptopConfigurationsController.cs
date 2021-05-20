using Microsoft.AspNetCore.Mvc;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Features.LaptopConfigs;
using System.Net;
using System.Threading.Tasks;

namespace NudgeDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopConfigurationsController : BaseController
    {
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLaptopConfigurationCommand command)
        {
            var res = await Mediator.Send(command);

            return Ok(res);
        }

    }
}
