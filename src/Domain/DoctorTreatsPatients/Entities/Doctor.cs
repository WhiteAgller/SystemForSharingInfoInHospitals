using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemForSharingInfoInHospitals.Domain.Entities.DoctorTreatsPatients;
public class Doctor : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Degree { get; set; }

    public int? DepartmentID { get; set; }
    public IList<HoursPerDay> OfficeHours { get; set;} = new List<HoursPerDay>();



}
