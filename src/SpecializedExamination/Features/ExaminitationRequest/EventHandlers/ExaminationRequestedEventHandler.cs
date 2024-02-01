using MediatR;
using Microsoft.Extensions.Logging;
using SpecializedExaminations.Domain.Events.ExaminitaionRequest;

public class ExaminationRequestedEventHandler(ILogger<ExaminationRequestedEventHandler> logger)
    : INotificationHandler<ExaminationRequestedEvent>
{

    public Task Handle(ExaminationRequestedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
