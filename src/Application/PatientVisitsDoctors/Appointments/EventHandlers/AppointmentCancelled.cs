using Microsoft.Extensions.Logging;
using SystemForSharingInfoInHospitals.Domain.Events.Appointment;

namespace SystemForSharingInfoInHospitals.Application.Appointments.EventHandlers;

public class AppointmentCancelledEventHandler(ILogger<AppointmentCancelledEvent> logger)
    : INotificationHandler<AppointmentCancelledEvent>
{
    public Task Handle(AppointmentCancelledEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
