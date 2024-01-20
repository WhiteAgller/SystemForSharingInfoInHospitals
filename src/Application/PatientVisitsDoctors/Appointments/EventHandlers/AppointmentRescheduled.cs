using Microsoft.Extensions.Logging;
using SystemForSharingInfoInHospitals.Domain.Events.Appointment;

namespace SystemForSharingInfoInHospitals.Application.Appointments.EventHandlers;

public class AppointmentRescheduledEventHandler(ILogger<AppointmentRescheduledEvent> logger)
    : INotificationHandler<AppointmentRescheduledEvent>
{
    public Task Handle(AppointmentRescheduledEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
