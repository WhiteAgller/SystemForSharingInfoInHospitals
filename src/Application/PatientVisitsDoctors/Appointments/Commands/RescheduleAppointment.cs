using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Domain.PatientVisitsDoctors.Enums;

namespace SystemForSharingInfoInHospitals.Application.Appointments.Commands;

public record ReschedulePatientCommand : IRequest
{
    public int Id { get; set; }
    
    public DateTime AppointmentDate { get; set; }
}

public class RecheduleAppointmentController : ApiControllerBase
{
    [HttpPut]
    public async Task<ActionResult> RescheduleAppointment(ReschedulePatientCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}

public class ReschedulePatientCommandHandler(IApplicationDbContext context) : IRequestHandler<ReschedulePatientCommand>
{
    public async Task Handle(ReschedulePatientCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Appointments.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);

        entity.Status = Status.Rescheduled;
        entity.AppointmentDate = request.AppointmentDate;
        
        await context.SaveChangesAsync(cancellationToken);
    }
}
