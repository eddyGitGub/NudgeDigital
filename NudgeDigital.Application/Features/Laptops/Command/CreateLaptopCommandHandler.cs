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
            var duplicateComponents = await _context.Configurations.AsNoTracking().Where(x => configIds.Contains(x.Id)).Include(x => x.Component)
                .GroupBy(x => x.Component).Where(g => g.Count() > 1).Select(y => y.Key).ToListAsync();

            if (duplicateComponents.Count > 0)
            {
                var items = string.Join(",", duplicateComponents.Select(x => x.Name));
                return ResponseModel.Failure($"You have selected duplicate components: {items}.");
            }

            var productExist = await _context.Laptops.AsNoTracking().Where(x => x.BrandId == request.BrandId && x.Configurations.Any(c => configIds.All(x => c.ConfigurationId == x))).AnyAsync();

            if (productExist)
            {
                return ResponseModel.Failure($"Laptop with the same brand and configurations already exists");
            }

            var model = _mapper.Map<Laptop>(request);
            var configs = new List<Domain.Entities.LaptopConfiguration>();
            foreach (var item in configIds)
            {
                configs.Add(new Domain.Entities.LaptopConfiguration { ConfigurationId = item });
            }
            

            model.Configurations = configs;
            await _context.Laptops.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ResponseModel.Success("Laptop was created successfully");
        }
    }
}
