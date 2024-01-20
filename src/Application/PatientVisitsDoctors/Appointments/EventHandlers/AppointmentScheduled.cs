using Microsoft.Extensions.Logging;
using SystemForSharingInfoInHospitals.Domain.Events.Appointment;

namespace SystemForSharingInfoInHospitals.Application.Appointments.EventHandlers;

public class AppointmentScheduledEventHandler(ILogger<AppointmentScheduledEvent> logger)
    : INotificationHandler<AppointmentScheduledEvent>
{
    public Task Handle(AppointmentScheduledEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}

