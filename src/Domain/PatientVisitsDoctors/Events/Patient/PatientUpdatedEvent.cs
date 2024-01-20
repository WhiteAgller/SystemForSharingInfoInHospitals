namespace SystemForSharingInfoInHospitals.Domain.Events;

public class PatientUpdatedEvent : BaseEvent
{
    public Patient Patient { get; set; }
    
    public PatientUpdatedEvent(Patient patient)
    {
        Patient = patient;
    }
}
