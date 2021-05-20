using MediatR;
using NudgeDigital.Application.Common.Models;
using System.Collections.Generic;

namespace NudgeDigital.Application.Features.Laptops.Command
{
    public class CreateLaptopCommand: IRequest<ResponseModel>
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual List<int> ConfigItems { get; set; }
    }

    //public class LaptopConfigRequest
    //{
    //    public int ComponentId { get; set; }
    //    public int ConfigurationId { get; set; }
    //}

    public class LaptopConfigError
    {
        public int ConfigurationId { get; set; }
        public string ComponentName { get; set; }
    }

    public class LaptopConfigSelectable
    {
        public int ConfigurationId { get; set; }
        public int ComponentId { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }
    }
}
