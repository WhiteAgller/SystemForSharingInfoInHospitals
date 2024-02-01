using Ardalis.GuardClauses;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpecializedExaminations.Infrastructure.Data;

namespace SpecializedExaminations.Features.ExaminitationRequest.Commands;

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

public class AssignExaminationCommandHandler(ISpecializedExaminationDbContext context) : IRequestHandler<AssignExaminationCommand>
{
    public async Task Handle(AssignExaminationCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ExaminationRequests.FindAsync(request.ExaminationRequestId);
        Guard.Against.NotFound(request.ExaminationRequestId, entity);

        entity.DoctorId = request.DoctorId;
        
        await context.SaveChangesAsync(cancellationToken);
    }
}
