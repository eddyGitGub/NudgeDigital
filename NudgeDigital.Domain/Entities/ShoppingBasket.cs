using NudgeDigital.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NudgeDigital.Domain.Entities
{
    public class ShoppingBasket: AuditableEntity
    {
        public string SessionId { get; set; }
        public int LaptopId { get; set; }
        public string Currency { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTimeOffset Date { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}
