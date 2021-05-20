using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Features.LaptopConfiguration.Command;
using NudgeDigital.Application.Features.LaptopConfiguration.Query;

namespace NudgeDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : BaseController
    {
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartCommand command)
        {
            var res = await Mediator.Send(command);

            return Ok(res);
        }

        //[ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(ResponseModel<List<CartModel>>), (int)HttpStatusCode.OK)]
        //[Produces("application/json")]
        //[HttpPost("UpdateCart")]
        //public async Task<IActionResult> UpdateCart([FromBody] UpdateCartCommand command)
        //{
        //    var res = await Mediator.Send(command);

        //    return Ok(res);
        //}

        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<CartVM>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpGet("GetByUser/{userId}")]
        public async Task<IActionResult> GetByUser([FromRoute] string sessionId)
        {
            var res = await Mediator.Send(new GetCartQuery(sessionId));

            return Ok(res);
        }

        //[ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        //[Produces("application/json")]
        //[HttpDelete("RemoveFromCart/{cartId}")]
        //public async Task<IActionResult> RemoveFromCart([FromRoute] long cartId)
        //{
        //    var res = await Mediator.Send(new RemoveCartItemCommand(cartId));

        //    return Ok(res);
        //}
    }
}
