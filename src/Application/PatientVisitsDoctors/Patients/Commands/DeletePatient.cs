using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Domain.Events;

namespace SystemForSharingInfoInHospitals.Application.Patients.Commands;

public record DeletePatientCommand(int Id) : IRequest;

public class DeletePatientController : ApiControllerBase
{
    [HttpDelete]
    public async Task<ActionResult<int>> DeletePatient(DeletePatientCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}

public class DeletePatientCommandHandler(IApplicationDbContext context) : IRequestHandler<DeletePatientCommand>
{
    public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Patients
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        context.Patients.Remove(entity);

        entity.AddDomainEvent(new PatientDeletedEvent(entity));

        await context.SaveChangesAsync(cancellationToken);
    }

}
