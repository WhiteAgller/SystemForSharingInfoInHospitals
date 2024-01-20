using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Domain.Entities;
using SystemForSharingInfoInHospitals.Domain.Enums;
using SystemForSharingInfoInHospitals.Domain.Events.Appointment;

namespace SystemForSharingInfoInHospitals.Application.Appointments.Commands;

public record ScheduleAppointmentCommand : IRequest<int>
{
    public int PatientId { get; set; }
    
    public int DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }
}

public class ScheduleAppointmentController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> ScheudleAppointment(ScheduleAppointmentCommand command)
    {
        return await Mediator.Send(command);
    }
}

public class ScheduleAppointmentCommandHandler(IApplicationDbContext context)
    : IRequestHandler<ScheduleAppointmentCommand, int>
{
    public async Task<int> Handle(ScheduleAppointmentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Appointment()
        {
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            AppointmentDate = request.AppointmentDate,
            Status = Status.Scheduled
        };

        entity.AddDomainEvent(new AppointmentScheduledEvent(entity));
        context.Appointments.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
