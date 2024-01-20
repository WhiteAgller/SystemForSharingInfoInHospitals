namespace SystemForSharingInfoInHospitals.Domain.Events;

public class PatientDeletedEvent : BaseEvent
{
    public Patient Patient;
    
    public PatientDeletedEvent(Patient patient)
    {
        Patient = patient;
    }
}
