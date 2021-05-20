using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NudgeDigital.Domain.Entities;

namespace NudgeDigital.Application.Features.Laptops.Command
{
    public class CreateLaptopCommandHandler : IRequestHandler<CreateLaptopCommand, ResponseModel>
    {
        private readonly INudgeDigitalDbContext _context;
        private readonly IMapper _mapper;
        public CreateLaptopCommandHandler(INudgeDigitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(CreateLaptopCommand request, CancellationToken cancellationToken)
        {
            var exist = await _context.Laptops.AsNoTracking().AnyAsync(c => c.BrandId == request.BrandId && c.Name.ToLower().Equals(request.Name.ToLower()));
            if (exist)
            {
                return ResponseModel.Failure($"Laptop with the name {request.Name} and brand already exists");
            }

            var configIds = request.ConfigItems.Distinct().ToList();

            // Do this to check if a laptop for the same configurations already exists
            //var existingComponent = await _context.Laptops.AsNoTracking()
            //    .AnyAsync(c => c.Name.ToLower().Equals(request.Name.ToLower())
            //    || c.BrandId == request.BrandId &&
            //    c.Configurations.GroupBy(x => new { x.ConfigurationId, x.Configuration.ComponentId })
            //    .Where(x => x.Skip(1).Any())
            //    .Any(x => configIds.Contains(x.Key.ConfigurationId)));

            //But for user experience, return the list the list of affected components / configurations
            //var configurations = await _context.Configurations.AsNoTracking().Where(x => configIds.Contains(x.Id)).ToListAsync();

            var getType = await _context.Configurations.AsNoTracking().Where(x => configIds.Contains(x.Id)).Select(s => s.ComponentId).ToListAsync();
            var check = getType.GroupBy(x => x).Any(g => g.Count() > 1);
            if (check)
            {
                //return ResponseModel.Failure($"Laptop with the name {request.Name} or the same configurations already exists");
                return new ResponseModel<List<LaptopConfigError>>()
                {
                    Message = "components of same type not allow",
                   // Data = 
                };

            }

            var existingComponents = await _context.Laptops.AsNoTracking()
                .Where(x => x.BrandId == request.BrandId && x.Configurations.Any(x => configIds.Contains(x.ConfigurationId)))
                .Include(x => x.Configurations).ThenInclude(x => x.Configuration).ThenInclude(x => x.Component)
                .SelectMany(x => x.Configurations.Select(x => new LaptopConfigError()
                {
                    ConfigurationId = x.ConfigurationId,
                    ComponentName = $"{x.Configuration.Component.Name} - {x.Configuration.ComponentType}"
                })).ToListAsync();

            if (existingComponents.Count > 0)
            {
                //return ResponseModel.Failure($"Laptop with the name {request.Name} or the same configurations already exists");
                return new ResponseModel<List<LaptopConfigError>>()
                {
                    Message = "There is an existing laptop with the selected components",
                    Data = existingComponents
                };

                //var checkConfig = await _context.LaptopConfigurations.AsNoTracking().GroupBy(x => new { x.ConfigurationId, x.Configuration.ComponentId }).AnyAsync(x => x.);
                //var hasDupes = dupList.GroupBy(x => new { x.checkThis, x.checkThat })
                //   .Where(x => x.Skip(1).Any()).Any();
                //var exist1 = await _context.Laptops.AsNoTracking().AnyAsync(c => c.Name.ToLower().Equals(request.Name.ToLower()) || c.BrandId == request.BrandId && c.Configurations.Any(x => configIds.Contains(x.ConfigurationId)));
            }
            var model = _mapper.Map<Laptop>(request);
            var configs = new List<Domain.Entities.LaptopConfiguration>();
            foreach (var item in configIds)
            {
                configs.Add(new Domain.Entities.LaptopConfiguration { ConfigurationId = item });
            }
            //for (int i = 0; i < configIds.Count; i++)
            //{
                
            //}

            model.Configurations = configs;
            await _context.Laptops.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ResponseModel.Success("Laptop was created successfully");
        }
    }
}
