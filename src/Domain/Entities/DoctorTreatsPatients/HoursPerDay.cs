using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemForSharingInfoInHospitals.Domain.Entities.DoctorTreatsPatients;
public class HoursPerDay: BaseAuditableEntity
{
    public int DoctorId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
}
