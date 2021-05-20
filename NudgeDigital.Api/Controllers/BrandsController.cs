using Microsoft.AspNetCore.Mvc;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Features.Brands.Command;
using NudgeDigital.Application.Features.Brands.Queries;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NudgeDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBrandCommand command)
        {
            var res = await Mediator.Send(command);

            return Ok(res);
        }


        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<BrandVM>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var res = await Mediator.Send(new GetAllBrandQuery());

            return Ok(res);
        }
    }
}
