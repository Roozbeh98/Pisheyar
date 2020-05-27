using MediatR;
using Microsoft.Extensions.Logging;
using Pisheyar.Application.Common.Interfaces;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Pisheyar.Application.Common.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUser;
        private readonly IIdentityService _identityService;

        public RequestPerformanceBehaviour(
            ILogger<TRequest> logger,
            ICurrentUserService currentUserService,
            IIdentityService identityService)
        {
            _timer = new Stopwatch();

            _logger = logger;
            _currentUser = currentUserService;
            _identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userNameIdentifier = _currentUser.NameIdentifier;
                string userFullName = string.Empty;

                if (!string.IsNullOrEmpty(userNameIdentifier))
                {
                    userFullName = await _identityService.GetUserFullNameAsync(Guid.Parse(userNameIdentifier));
                }

                _logger.LogWarning("Pisheyar Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@userNameIdentifier} {@userFullName} {@Request}",
                    requestName, elapsedMilliseconds, userNameIdentifier, userFullName, request);
            }

            return response;
        }
    }
}
