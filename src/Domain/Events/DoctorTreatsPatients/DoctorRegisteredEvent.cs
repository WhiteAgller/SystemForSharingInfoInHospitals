using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemForSharingInfoInHospitals.Domain.Entities.DoctorTreatsPatients;

namespace SystemForSharingInfoInHospitals.Domain.Events.DoctorTreatsPatients;
public class DoctorRegisteredEvent : BaseEvent
{
    public DoctorRegisteredEvent(Doctor doctor)
    {
        Doctor = doctor;
    }

    public Doctor Doctor { get; }
}
