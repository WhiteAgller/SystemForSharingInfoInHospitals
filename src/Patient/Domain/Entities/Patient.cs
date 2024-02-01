using Common.DomainCommon;
using PatientManagement.Domain.ValueObjects;

namespace PatientManagement.Domain.Entities;

public class Patient : BaseAuditableEntity
{
    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public IEnumerable<Alergy> Alergies { get; set; } = new List<Alergy>();

    public MedicalRecord MedicalRecord { get; set; } = new();
}
