using Microsoft.Extensions.Logging;
using SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.Events.ExaminitaionRequest;

namespace SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.ExaminitationRequest.EventHandlers;

public class ExaminationCompletedEventHandler(ILogger<ExaminationCompletedEvent> logger)
    : INotificationHandler<ExaminationCompletedEvent>
{

    public Task Handle(ExaminationCompletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}
