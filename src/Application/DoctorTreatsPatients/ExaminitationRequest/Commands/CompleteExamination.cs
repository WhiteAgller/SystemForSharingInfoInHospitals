using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;

namespace SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.ExaminitationRequest.Commands;

public record CompleteExaminationCommand : IRequest
{
    public int ExaminationRequestId { get; set; }

    public string Result { get; set; } = null!;
}

public class CompleteExaminationController : ApiControllerBase
{
    [HttpPut]
    public async Task<ActionResult> CompleteExamination(CompleteExaminationCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}

public class CompleteExaminationCommandHandler(IApplicationDbContext context) : IRequestHandler<CompleteExaminationCommand>
{
    public async Task Handle(CompleteExaminationCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ExaminationRequests.FindAsync(request.ExaminationRequestId);
        Guard.Against.NotFound(request.ExaminationRequestId, entity);

        entity.IsFinished = true;
        entity.Result = request.Result;
        
        await context.SaveChangesAsync(cancellationToken);
    }
}
