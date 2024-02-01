using Appointments.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Appointments.Features.EventHandlers;

public class AppointmentScheduledEventHandler(ILogger<AppointmentScheduledEvent> logger)
    : INotificationHandler<AppointmentScheduledEvent>
{
    public Task Handle(AppointmentScheduledEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}

