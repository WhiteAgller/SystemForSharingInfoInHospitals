using SystemForSharingInfoInHospitals.Domain.Entities;
using SystemForSharingInfoInHospitals.Domain.ValueObjects;

namespace Microsoft.Extensions.DependencyInjection.Patients.Queries;

public class GetPatientDto
{
    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public IEnumerable<Alergy> Alergies { get; set; } = new List<Alergy>();

    public MedicalRecord MedicalRecord { get; set; } = new();
}
