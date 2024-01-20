namespace SystemForSharingInfoInHospitals.Domain.Events;

public class PatientRegisteredEvent : BaseEvent
{
    public Patient Patient;
    
    public PatientRegisteredEvent(Patient patient)
    {
        Patient = patient;
    }
}
