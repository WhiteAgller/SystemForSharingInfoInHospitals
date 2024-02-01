using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpecializedExaminations.Domain.Entities;
using SpecializedExaminations.Domain.Events.ExaminitaionRequest;
using SpecializedExaminations.Infrastructure.Data;

namespace SpecializedExaminations.Features.ExaminitationRequest.Commands;

public record RequestExaminationCommand : IRequest<int>
{
    public int PatientId { get; set; }
    
    public int ToDepartmentId { get; set; }

    public string ToSpecializedWorkplace { get; set; } = null!;
}

public class RequestExaminationController : ApiControllerBase
{
    [HttpPut]
    public async Task<ActionResult> RequestExamination(RequestExaminationCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}

public class RequestExaminationCommandHandler(ISpecializedExaminationDbContext context)
    : IRequestHandler<RequestExaminationCommand, int>
{
    public async Task<int> Handle(RequestExaminationCommand request, CancellationToken cancellationToken)
    {
        var entity = new ExaminationRequest()
        {
            PatientId = request.PatientId,
            ToDepartmentId = request.ToDepartmentId,
            ToSpecializedWorkplace = request.ToSpecializedWorkplace,
            IsFinished = false
        };
        
        entity.AddDomainEvent(new ExaminationRequestedEvent(entity));
        context.ExaminationRequests.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
