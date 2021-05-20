using MediatR;
using NudgeDigital.Application.Common.Models;
using NudgeDigital.Application.Enums;

namespace NudgeDigital.Application.Features.LaptopConfigs
{
    public class CreateLaptopConfigurationCommand:IRequest<ResponseModel>
    {
        public int LaptopId { get; set; }
        public int ConfigurationId { get; set; }
        public ConfigurationTypeEnum ConfigurationType { get; set; }
    }
}
