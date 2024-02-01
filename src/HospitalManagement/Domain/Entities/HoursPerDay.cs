using Common.DomainCommon;

namespace HospitalManagement.Domain.Entities;
public class HoursPerDay : BaseAuditableEntity
{
    public int DoctorId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
}
