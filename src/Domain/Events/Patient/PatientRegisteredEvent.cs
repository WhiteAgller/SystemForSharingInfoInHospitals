namespace SystemForSharingInfoInHospitals.Domain.Events;

public class PatientRegisteredEvent : BaseEvent
{
    public Patient Patient { get; set; }
    
    public PatientRegisteredEvent(Patient patient)
    {
        Patient = patient;
    }
}
