using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace NudgeDigital.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        //private readonly ICurrentUserService _currentUserService;

        public LoggingBehaviour(ILogger<TRequest> logger) // , IIdentityService identityService
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            

            _logger.LogInformation("NudgeDigital Request: {Name}{@Request}",
                requestName,request);

            await Task.FromResult(0);
        }
    }
}
