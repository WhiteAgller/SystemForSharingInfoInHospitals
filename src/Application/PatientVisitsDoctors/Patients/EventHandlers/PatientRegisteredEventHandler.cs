using Microsoft.Extensions.Logging;
using SystemForSharingInfoInHospitals.Domain.Events;

namespace SystemForSharingInfoInHospitals.Application.PatientVisitsDoctors.Patients.EventHandlers;

public class PatientRegisteredEventHandler(ILogger<PatientRegisteredEvent> logger)
    : INotificationHandler<PatientRegisteredEvent>
{
    public Task Handle(PatientRegisteredEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
