using MediatR;
using Microsoft.EntityFrameworkCore;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Contracts.Persistence;
using NudgeDigital.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NudgeDigital.Application.Features.LaptopConfiguration.Command
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, ResponseModel>
    {
        private readonly INudgeDigitalDbContext _dbcontext;

        public AddToCartCommandHandler(INudgeDigitalDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<ResponseModel> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var sessionId = await _dbcontext.Carts.AsNoTracking().Where(x => x.LaptopId == request.ItemId).Select(x => x.SessionId).FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(sessionId))
            {
                sessionId = Guid.NewGuid().ToString();
            }

            var item = await _dbcontext.Carts.AsNoTracking().FirstOrDefaultAsync(x => x.LaptopId == request.ItemId && x.SessionId == sessionId);
            if (item != null)
            {
                item.SessionId = sessionId;
                item.UnitPrice = request.UnitPrice;
                item.Quantity = request.Quantity;
                item.TotalAmount = item.UnitPrice * item.Quantity;
                _dbcontext.Carts.Update(item);
                await _dbcontext.SaveChangesAsync();
                return ResponseModel.Success("Cart Updated!");
            }
            else
            {
                var model = new ShoppingBasket()
                {

                    LaptopId = request.ItemId,
                    SessionId = sessionId,
                    Quantity = request.Quantity,
                    UnitPrice = request.UnitPrice,
                    Date = request.Date
                };

                model.TotalAmount = model.UnitPrice * model.Quantity;
                _dbcontext.Carts.Add(model);
                await _dbcontext.SaveChangesAsync();
                return ResponseModel.Success("Added to Cart");
            }
        }
    }
}
