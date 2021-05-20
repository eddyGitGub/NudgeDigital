using MediatR;
using System.Collections.Generic;

namespace NudgeDigital.Application.Features.Laptops.Query
{
    public class GetAllLaptopQuery: IRequest<List<LaptopVM>>
    {
    }
}
