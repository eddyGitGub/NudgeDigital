using MediatR;
using NudgeDigital.Application.Features.Configurations.Queries;
using System.Collections.Generic;

namespace NudgeDigital.Application.Features.Configurations.Query
{
    public class GetConfigurationQuery: IRequest<List<ConfigurationVM>>
    {
    }
}
