using MediatR;
using System.Collections.Generic;

namespace NudgeDigital.Application.Features.Brands.Queries
{
    public class GetAllBrandQuery: IRequest<List<BrandVM>>
    {
    }
}
