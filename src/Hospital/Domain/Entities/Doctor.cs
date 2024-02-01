using Common.DomainCommon;


namespace HospitalManagement.Domain.Entities;
public class Doctor : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string? Surname { get; set; }
    public string? Degree { get; set; }

    public int? DepartmentId { get; set; }
    public IList<HoursPerDay> OfficeHours { get; set;} = new List<HoursPerDay>();



}
