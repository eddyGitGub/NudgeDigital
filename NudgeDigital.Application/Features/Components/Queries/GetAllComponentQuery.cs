using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NudgeDigital.Application.Features.Components.Queries
{
    public class GetAllComponentQuery: IRequest<List<ComponentVM>>
    {
    }
}
