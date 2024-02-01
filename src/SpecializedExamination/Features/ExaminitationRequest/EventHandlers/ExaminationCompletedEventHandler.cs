using MediatR;
using Microsoft.Extensions.Logging;
using SpecializedExaminations.Domain.Events.ExaminitaionRequest;

namespace SpecializedExaminations.Features.ExaminitationRequest.EventHandlers;

public class ExaminationCompletedEventHandler(ILogger<ExaminationCompletedEvent> logger)
    : INotificationHandler<ExaminationCompletedEvent>
{

    public Task Handle(ExaminationCompletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}
