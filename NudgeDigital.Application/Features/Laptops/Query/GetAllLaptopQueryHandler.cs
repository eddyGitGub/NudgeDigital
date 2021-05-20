using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NudgeDigital.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NudgeDigital.Application.Features.Laptops.Query
{
    public class GetAllLaptopQueryHandler : IRequestHandler<GetAllLaptopQuery, List<LaptopVM>>
    {
        private readonly INudgeDigitalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllLaptopQueryHandler(INudgeDigitalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<LaptopVM>> Handle(GetAllLaptopQuery request, CancellationToken cancellationToken)
        {
            var reponse = await _dbContext.Laptops.Include(b=>b.Brand).Include(x=>x.Configurations).ThenInclude(y=>y.Configuration).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            var data = _mapper.Map<List<LaptopVM>>(reponse);

            return data;
        }
    }
}
