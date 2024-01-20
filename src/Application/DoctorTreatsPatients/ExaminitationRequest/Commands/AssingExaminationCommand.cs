using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;

namespace SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.ExaminitationRequest.Commands;

public record AssignExaminationCommand : IRequest
{
    public int ExaminationRequestId { get; set; }
    
    public int DoctorId { get; set; }
}

public class AssignExaminationController : ApiControllerBase
{
    [HttpPut]
    public async Task<ActionResult> AssignExamination(AssignExaminationCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}

public class AssignExaminationCommandHandler(IApplicationDbContext context) : IRequestHandler<AssignExaminationCommand>
{
    public async Task Handle(AssignExaminationCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ExaminationRequests.FindAsync(request.ExaminationRequestId);
        Guard.Against.NotFound(request.ExaminationRequestId, entity);

        entity.DoctorId = request.DoctorId;
        
        await context.SaveChangesAsync(cancellationToken);
    }
}
