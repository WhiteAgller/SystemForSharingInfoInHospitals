using Microsoft.Extensions.Logging;
using SystemForSharingInfoInHospitals.Domain.Events;

namespace SystemForSharingInfoInHospitals.Application.Patients.EventHandlers;

public class PatientDeletedEventHandler(ILogger<PatientDeletedEvent> logger)
    : INotificationHandler<PatientDeletedEvent>
{
    public Task Handle(PatientDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
