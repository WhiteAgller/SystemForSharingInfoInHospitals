using MediatR;
using Microsoft.Extensions.Logging;
using PatientManagement.Domain.Events.MedicalRecord;

namespace PatientManagement.Features.MedicalRecords.EventHandlers;

public class DiagnosesAddedHandler(ILogger<DiagnosisAddedEvent> logger)
    : INotificationHandler<DiagnosisAddedEvent>
{
    public Task Handle(DiagnosisAddedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
