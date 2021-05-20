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

namespace NudgeDigital.Application.Features.LaptopConfiguration.Query
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, List<CartVM>>
    {
        private readonly INudgeDigitalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCartQueryHandler(INudgeDigitalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CartVM>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
           
            var response = await _dbContext.Carts.AsNoTracking().Where(x=>x.SessionId == request.SessionId).Include(x=> x.Laptop).ThenInclude(x=>x.Configurations).ThenInclude(y=>y.Configuration).ToListAsync();
            var data = _mapper.Map<List<CartVM>>(response);

            return data;
        }
    }
}
