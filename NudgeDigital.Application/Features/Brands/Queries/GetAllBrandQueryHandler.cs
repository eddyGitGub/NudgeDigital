using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NudgeDigital.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NudgeDigital.Application.Features.Brands.Queries
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, List<BrandVM>>
    {
        private readonly INudgeDigitalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllBrandQueryHandler(INudgeDigitalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<BrandVM>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            var reponse = await _dbContext.Brands.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            var data = _mapper.Map<List<BrandVM>>(reponse);

            return data;
        }
    }
}
