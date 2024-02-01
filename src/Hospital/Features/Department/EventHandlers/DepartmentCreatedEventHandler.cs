using HospitalManagement.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HospitalManagement.Features.Department.EventHandlers;
public class DepartmentCreatedEventHandler : INotificationHandler<DepartmentCreatedEvent>
{
    private readonly ILogger<DepartmentCreatedEventHandler> _logger;

    public DepartmentCreatedEventHandler(ILogger<DepartmentCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DepartmentCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SystemForSharingInfoInHospitals Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
