using MediatR;
using Microsoft.Extensions.Logging;
using PatientManagement.Domain.Events.Patient;

namespace PatientManagement.Features.Patients.EventHandlers;

public class PatientUpdatedEventHandler(ILogger<PatientUpdatedEvent> logger)
    : INotificationHandler<PatientUpdatedEvent>
{
    public Task Handle(PatientUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
