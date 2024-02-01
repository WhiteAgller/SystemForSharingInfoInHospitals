using Appointments.Domain.Enums;
using Appointments.Infrastructure.Data;
using Ardalis.GuardClauses;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Features.Commands;

public record CancelPatientCommand : IRequest
{
    public int Id { get; set; }
    
    public DateTime AppointmentDate { get; set; }
}

public class CancelAppointmentController : ApiControllerBase
{
    [HttpPut]
    public async Task<ActionResult> CancelAppointment(ReschedulePatientCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}

public class CancelPatientCommandHandler(IAppointmentDbContext context) : IRequestHandler<CancelPatientCommand>
{
    public async Task Handle(CancelPatientCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Appointments.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);

        entity.Status = Status.Canceled;
        entity.AppointmentDate = DateTime.MinValue;
        
        await context.SaveChangesAsync(cancellationToken);
    }
}
