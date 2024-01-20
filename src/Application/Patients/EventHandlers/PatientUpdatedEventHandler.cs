using Microsoft.Extensions.Logging;
using SystemForSharingInfoInHospitals.Domain.Events;

namespace SystemForSharingInfoInHospitals.Application.Patients.EventHandlers;

public class PatientUpdatedEventHandler(ILogger<PatientUpdatedEvent> logger)
    : INotificationHandler<PatientUpdatedEvent>
{
    public Task Handle(PatientUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
