using NudgeDigital.Domain.Common;
using System;
using System.Collections.Generic;

namespace NudgeDigital.Application.Features.LaptopConfiguration.Query
{
    public class CartVM
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string SessionId { get; set; }
        public List<string> Configurations { get; set; }
        public DateTimeOffset Date { get; set; }
    }
   
}