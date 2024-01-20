using SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.ValueObjects;
using SystemForSharingInfoInHospitals.Domain.Entities.DoctorTreatsPatients;

namespace SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.Entities;
public class Department : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public List<SpecializedWorkplace> SpecializedWorkplaces { get; set; } = new List<SpecializedWorkplace>();
    
    public IList<Doctor> Doctors { get; set; } = new List<Doctor>();
}
