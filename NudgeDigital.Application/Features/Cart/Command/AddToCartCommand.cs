using MediatR;
using NudgeDigital.Application.Common.Models;
using System;

namespace NudgeDigital.Application.Features.LaptopConfiguration.Command
{
    public class AddToCartCommand : IRequest<ResponseModel>
    {
       
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Currency { get; set; }
        public int Quantity { get; set; } = 1;
        public DateTimeOffset Date { get; set; }
    }
}
