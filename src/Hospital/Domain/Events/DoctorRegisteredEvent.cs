using Common.DomainCommon;
using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Domain.Events;
public class DoctorRegisteredEvent : BaseEvent
{
    public DoctorRegisteredEvent(Doctor doctor)
    {
        Doctor = doctor;
    }

    public Doctor Doctor { get; }
}
