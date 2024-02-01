using Common.DomainCommon;

namespace PatientManagement.Domain.Events.Patient;

public class PatientDeletedEvent : BaseEvent
{
    public Entities.Patient Patient { get; set; }
    
    public PatientDeletedEvent(Entities.Patient patient)
    {
        Patient = patient;
    }
}
