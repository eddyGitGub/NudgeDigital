using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NudgeDigital.Application.Contracts.Persistence;
using NudgeDigital.Application.Features.Configurations.Query;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NudgeDigital.Application.Features.Configurations.Queries
{
    public class GetConfigurationQueryHandler : IRequestHandler<GetConfigurationQuery, List<ConfigurationVM>>
    {
        private readonly INudgeDigitalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetConfigurationQueryHandler(INudgeDigitalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<ConfigurationVM>> Handle(GetConfigurationQuery request, CancellationToken cancellationToken)
        {
            var reponse = await _dbContext.Configurations.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            var data = _mapper.Map<List<ConfigurationVM>>(reponse);

            return data;
        }
    }
}
