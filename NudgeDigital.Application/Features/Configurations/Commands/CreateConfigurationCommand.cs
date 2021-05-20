using MediatR;
using NudgeDigital.Application.Common.Models;

namespace NudgeDigital.Application.Features.Configurations.Command
{
    public class CreateConfigurationCommand: IRequest<ResponseModel>
    {
        public int ComponentId { get; set; }
        public string ComponentType { get; set; }
        public decimal Price { get; set; }
    }
}
