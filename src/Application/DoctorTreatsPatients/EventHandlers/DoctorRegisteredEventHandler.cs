using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SystemForSharingInfoInHospitals.Domain.Events.DoctorTreatsPatients;

namespace SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.EventHandlers;
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
