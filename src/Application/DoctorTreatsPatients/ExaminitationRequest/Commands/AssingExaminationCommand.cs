using SystemForSharingInfoInHospitals.Application.Common.Interfaces;

namespace SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.ExaminitationRequest.Commands;

public record AssignExaminationCommand : IRequest
{
    public int ExaminationRequestId { get; set; }
    
    public int DoctorId { get; set; }
}


public class ReschedulePatientCommandHandler(IApplicationDbContext context) : IRequestHandler<AssignExaminationCommand>
{
    public async Task Handle(AssignExaminationCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ExaminationRequests.FindAsync(request.ExaminationRequestId);
        Guard.Against.NotFound(request.ExaminationRequestId, entity);

        entity.DoctorId = request.DoctorId;
        
        await context.SaveChangesAsync(cancellationToken);
    }
}
