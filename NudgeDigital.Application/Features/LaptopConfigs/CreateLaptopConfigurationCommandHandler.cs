using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace NudgeDigital.Application.Features.LaptopConfigs
{
    public class CreateLaptopConfigurationCommandHandler : IRequestHandler<CreateLaptopConfigurationCommand, ResponseModel>
    {
        private readonly INudgeDigitalDbContext _context;
        private readonly IMapper _mapper;
        public CreateLaptopConfigurationCommandHandler(INudgeDigitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseModel> Handle(CreateLaptopConfigurationCommand request, CancellationToken cancellationToken)
        {
            var exist = await _context.LaptopConfigurations.AsNoTracking().AnyAsync(c => c.LaptopId== request.LaptopId && c.Configuration.ComponentType.Equals(request.ConfigurationType), cancellationToken: cancellationToken);
            if (exist)
            {
                return ResponseModel.Failure($"Laptop with Configuration  already exists");
            }
            var model = _mapper.Map<Domain.Entities.LaptopConfiguration>(request);
            await _context.LaptopConfigurations.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ResponseModel.Success("Configuration was created successfully");
        }
    }
}
