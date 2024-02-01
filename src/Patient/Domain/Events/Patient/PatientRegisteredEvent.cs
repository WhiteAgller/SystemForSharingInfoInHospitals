using Common.DomainCommon;

namespace PatientManagement.Domain.Events.Patient;

public class PatientRegisteredEvent : BaseEvent
{
    public Entities.Patient Patient { get; set; }
    
    public PatientRegisteredEvent(Entities.Patient patient)
    {
        Patient = patient;
    }
}
