using SystemForSharingInfoInHospitals.Application.Common.Interfaces;

namespace SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.ExaminitationRequest.Commands;

public record CompleteExaminationCommand : IRequest
{
    public int ExaminationRequestId { get; set; }
}

public class CompleteExaminationCommandHandler(IApplicationDbContext context) : IRequestHandler<CompleteExaminationCommand>
{
    public async Task Handle(CompleteExaminationCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ExaminationRequests.FindAsync(request.ExaminationRequestId);
        Guard.Against.NotFound(request.ExaminationRequestId, entity);

        entity.IsFinished = true;
        
        await context.SaveChangesAsync(cancellationToken);
    }
}
