using System.Collections.Generic;

namespace NudgeDigital.Application.Features.Laptops.Query
{
    public class LaptopVM
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> Configurations { get; set; }
        public decimal PriceTotal { get; set; }
    }
}