using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.Entities;
using SystemForSharingInfoInHospitals.Domain.Entities.DoctorTreatsPatients;

namespace SystemForSharingInfoInHospitals.Domain.Events.DoctorTreatsPatients;
public class DepartmentCreatedEvent : BaseEvent
{
    public DepartmentCreatedEvent(Department department)
    {
        Department = department;
    }
    public Department Department { get; set;}
}
