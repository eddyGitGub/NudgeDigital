using MediatR;
using System.Collections.Generic;

namespace NudgeDigital.Application.Features.LaptopConfiguration.Query
{
    public class GetCartQuery : IRequest<List<CartVM>>
    {
        public GetCartQuery(string sessionId)
        {
            SessionId = sessionId;
        }

        public string SessionId { get; set; }
    }

   

}
