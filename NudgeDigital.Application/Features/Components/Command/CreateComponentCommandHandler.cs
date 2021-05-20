using AutoMapper;
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

namespace NudgeDigital.Application.Features.Components.Command
{
    public class CreateComponentCommandHandler : IRequestHandler<CreateComponentCommand, ResponseModel>
    {
        private readonly INudgeDigitalDbContext _context;
        public CreateComponentCommandHandler(INudgeDigitalDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateComponentCommand request, CancellationToken cancellationToken)
        {
            var exist = await _context.Components.AsNoTracking().AnyAsync(c => c.Name.ToLower().Equals(request.Name.ToLower()), cancellationToken: cancellationToken);
            if (exist)
            {
                return ResponseModel.Failure($"This Name already exists");
            }
            var model = new Component {Name= request.Name };
            await _context.Components.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

           
            return ResponseModel.Success("Component was created successfully");
        }
    }
}
