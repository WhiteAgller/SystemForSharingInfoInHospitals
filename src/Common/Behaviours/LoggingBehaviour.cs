using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;


    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId =  string.Empty;
        string userName = "System";

        _logger.LogInformation("SystemForSharingInfoInHospitals Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, request);
        
        return Task.CompletedTask;
    }
}
