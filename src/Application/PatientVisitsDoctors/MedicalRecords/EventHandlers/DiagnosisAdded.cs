using Microsoft.Extensions.Logging;
using SystemForSharingInfoInHospitals.Domain.Events.MedicalRecord;

namespace SystemForSharingInfoInHospitals.Application.MedicalRecords.EventHandlers;

public class DiagnosesAddedHandler(ILogger<DiagnosisAddedEvent> logger)
    : INotificationHandler<DiagnosisAddedEvent>
{
    public Task Handle(DiagnosisAddedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
