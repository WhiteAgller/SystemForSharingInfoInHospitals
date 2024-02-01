using HospitalManagement.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HospitalManagement.Features.Doctor.EventHandlers;
internal class DoctorRegisteredEventHandler : INotificationHandler<DoctorRegisteredEvent>
{
    private readonly ILogger<DoctorRegisteredEventHandler> _logger;

    public DoctorRegisteredEventHandler(ILogger<DoctorRegisteredEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DoctorRegisteredEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SystemForSharingInfoInHospitals Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}
