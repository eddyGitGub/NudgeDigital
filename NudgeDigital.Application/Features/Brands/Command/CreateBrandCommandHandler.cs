using MediatR;
using Microsoft.EntityFrameworkCore;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Contracts.Persistence;
using NudgeDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NudgeDigital.Application.Features.Brands.Command
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ResponseModel>
    {
        private readonly INudgeDigitalDbContext _context;
        public CreateBrandCommandHandler(INudgeDigitalDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var exist = await _context.Brands.AsNoTracking().AnyAsync(c =>  c.Name.ToLower().Equals(request.Name.ToLower()), cancellationToken: cancellationToken);
            if (exist)
            {
                return ResponseModel.Failure($"This Brand  already exists");
            }
            var model =new Brand {Name= request.Name };
            await _context.Brands.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return ResponseModel.Success("Brand was created successfully");
        }
    }
}
