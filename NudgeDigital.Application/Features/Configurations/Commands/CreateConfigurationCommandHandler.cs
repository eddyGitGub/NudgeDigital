using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Contracts.Persistence;
using NudgeDigital.Application.Features.Configurations.Command;
using NudgeDigital.Application.Features.Configurations.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace NudgeDigital.Application.Features.Configuration.Command
{
    public class CreateConfigurationCommandHandler : IRequestHandler<CreateConfigurationCommand, ResponseModel>
    {
        private readonly INudgeDigitalDbContext _context;
        private readonly IMapper _mapper;
        public CreateConfigurationCommandHandler(INudgeDigitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseModel> Handle(CreateConfigurationCommand request, CancellationToken cancellationToken)
        {
            var exist = await _context.Configurations.AsNoTracking().AnyAsync(c => c.ComponentId == request.ComponentId && c.ComponentType.ToLower().Equals(request.ComponentType.ToLower()), cancellationToken: cancellationToken);
            if (exist)
            {
                return ResponseModel.Failure($"This Configuration settings already exists");
            }
            var model = _mapper.Map<Domain.Entities.Configuration>(request);
            await  _context.Configurations.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var result = _mapper.Map<ConfigurationVM>(model);
            return ResponseModel<ConfigurationVM>.Success(result, "Configuration was created successfully");
        }
    }
}
