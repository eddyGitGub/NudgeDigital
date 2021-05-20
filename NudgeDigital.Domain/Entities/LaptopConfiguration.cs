using NudgeDigital.Domain.Common;
using NudgeDigital.Domain.Enums;
using System.Collections.Generic;

namespace NudgeDigital.Domain.Entities
{
    public class LaptopConfiguration: AuditableEntity
    {
        public int LaptopId { get; set; }
        public int ConfigurationId { get; set; }

        public virtual Laptop Laptop { get; set; }
        public virtual Configuration Configuration { get; set; }
    }
}
