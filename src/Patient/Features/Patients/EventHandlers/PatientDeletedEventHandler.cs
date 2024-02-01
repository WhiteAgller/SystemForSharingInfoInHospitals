using MediatR;
using Microsoft.Extensions.Logging;
using PatientManagement.Domain.Events.Patient;

namespace PatientManagement.Features.Patients.EventHandlers;

public class PatientDeletedEventHandler(ILogger<PatientDeletedEvent> logger)
    : INotificationHandler<PatientDeletedEvent>
{
    public Task Handle(PatientDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
