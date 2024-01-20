using Microsoft.Extensions.Logging;
using SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.Events.ExaminitaionRequest;

public class ExaminationRequestedEventHandler(ILogger<ExaminationRequestedEventHandler> logger)
    : INotificationHandler<ExaminationRequestedEvent>
{

    public Task Handle(ExaminationRequestedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
