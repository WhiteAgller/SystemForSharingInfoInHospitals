using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Domain.Entities;
using SystemForSharingInfoInHospitals.Domain.ValueObjects;

namespace SystemForSharingInfoInHospitals.Application.Patients.Commands;

public record UpdatePatientCommand : IRequest
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public IEnumerable<Alergy> Alergies { get; set; } = new List<Alergy>();

    public MedicalRecord MedicalRecord { get; set; } = new();
}

public class UpdatePatientCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdatePatientCommand>
{
    public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Patients.FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Alergies = request.Alergies;
        entity.Name = request.Name;
        entity.MedicalRecord = request.MedicalRecord;
        entity.DateOfBirth = request.DateOfBirth;

        await context.SaveChangesAsync(cancellationToken);
    }
}
