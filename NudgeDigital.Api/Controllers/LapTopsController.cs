using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Features.Laptops.Command;
using NudgeDigital.Application.Features.Laptops.Query;

namespace NudgeDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopsController : BaseController
    {
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLaptopCommand command)
        {
            var res = await Mediator.Send(command);

            return Ok(res);
        }

        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<LaptopVM>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var res = await Mediator.Send(new GetAllLaptopQuery());

            return Ok(res);
        }


    }
}
