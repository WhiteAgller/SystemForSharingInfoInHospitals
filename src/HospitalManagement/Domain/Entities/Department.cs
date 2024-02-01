using Common.DomainCommon;
using HospitalManagement.Domain.ValueObjects;

namespace HospitalManagement.Domain.Entities;
public class Department : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public List<SpecializedWorkplace> SpecializedWorkplaces { get; set; } = new List<SpecializedWorkplace>();
    
    public IList<Doctor> Doctors { get; set; } = new List<Doctor>();
}
