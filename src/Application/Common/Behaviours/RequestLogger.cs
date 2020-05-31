using Pisheyar.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Pisheyar.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUser;
        private readonly IIdentityService _identityService;

        public RequestLogger(ILogger<TRequest> logger, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _logger = logger;
            _currentUser = currentUserService;
            _identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userNameIdentifier = _currentUser.NameIdentifier ?? string.Empty;
            string userFullName = string.Empty;
            
            if (!string.IsNullOrEmpty(userNameIdentifier))
            {
                userFullName = await _identityService.GetUserFullNameAsync(Guid.Parse(userNameIdentifier));
            }

            _logger.LogInformation("Pisheyar Request: {Name} {@userGuid} {@userFullName} {@Request}",
                requestName, userNameIdentifier, userFullName, request);
        }
    }
}
