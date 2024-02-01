using Appointments.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Appointments.Features.EventHandlers;

public class AppointmentRescheduledEventHandler(ILogger<AppointmentRescheduledEvent> logger)
    : INotificationHandler<AppointmentRescheduledEvent>
{
    public Task Handle(AppointmentRescheduledEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
