using MediatR;
using Microsoft.Extensions.Logging;
using PatientManagement.Domain.Events.Patient;

namespace PatientManagement.Features.Patients.EventHandlers;

public class PatientRegisteredEventHandler(ILogger<PatientRegisteredEvent> logger)
    : INotificationHandler<PatientRegisteredEvent>
{
    public Task Handle(PatientRegisteredEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
