using Common.DomainCommon;

namespace PatientManagement.Domain.Events.Patient;

public class PatientUpdatedEvent : BaseEvent
{
    public Entities.Patient Patient { get; set; }
    
    public PatientUpdatedEvent(Entities.Patient patient)
    {
        Patient = patient;
    }
}
