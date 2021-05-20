using MediatR;
using NudgeDigital.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NudgeDigital.Application.Features.Components.Command
{
    public class CreateComponentCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
    }
}
