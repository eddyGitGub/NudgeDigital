using NudgeDigital.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NudgeDigital.Domain.Entities
{
    public class Laptop: AuditableEntity
    {
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ItemInStock { get; set; }

        public virtual ICollection<LaptopConfiguration> Configurations { get; set; }
    }
}
