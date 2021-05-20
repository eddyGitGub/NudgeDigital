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

namespace NudgeDigital.Application.Features.Components.Queries
{
    public class GetAllComponentQueryHandler : IRequestHandler<GetAllComponentQuery, List<ComponentVM>>
    {
        private readonly INudgeDigitalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllComponentQueryHandler(INudgeDigitalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<ComponentVM>> Handle(GetAllComponentQuery request, CancellationToken cancellationToken)
        {
            var reponse = await _dbContext.Components.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            var data = _mapper.Map<List<ComponentVM>>(reponse);

            return data;
        }
    }
}
