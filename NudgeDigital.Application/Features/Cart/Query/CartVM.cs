using NudgeDigital.Domain.Common;
using System;

namespace NudgeDigital.Application.Features.LaptopConfiguration.Query
{
    public class CartVM: AuditableEntity
    {
        public int? UserId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string SessionId { get; set; } // Use session
        public DateTimeOffset Date { get; set; }
    }
}