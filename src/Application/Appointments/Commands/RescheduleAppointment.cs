using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Domain.Enums;

namespace SystemForSharingInfoInHospitals.Application.Appointments.Commands;

public record ReschedulePatientCommand : IRequest
{
    public int Id { get; set; }
    
    public DateTime AppointmentDate { get; set; }
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
