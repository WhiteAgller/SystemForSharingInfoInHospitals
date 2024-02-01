using Appointments.Domain.Entities;
using Appointments.Domain.Enums;
using Appointments.Domain.Events;
using Appointments.Infrastructure.Data;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Features.Commands;

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

public class ScheduleAppointmentCommandHandler(IAppointmentDbContext context)
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
