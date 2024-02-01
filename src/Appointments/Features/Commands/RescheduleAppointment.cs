using Appointments.Domain.Enums;
using Appointments.Infrastructure.Data;
using Ardalis.GuardClauses;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Features.Commands;

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

public class ReschedulePatientCommandHandler(IAppointmentDbContext context) : IRequestHandler<ReschedulePatientCommand>
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
