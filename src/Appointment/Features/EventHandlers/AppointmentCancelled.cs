using Appointments.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Appointments.Features.EventHandlers;

public class AppointmentCancelledEventHandler(ILogger<AppointmentCancelledEvent> logger)
    : INotificationHandler<AppointmentCancelledEvent>
{
    public Task Handle(AppointmentCancelledEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
