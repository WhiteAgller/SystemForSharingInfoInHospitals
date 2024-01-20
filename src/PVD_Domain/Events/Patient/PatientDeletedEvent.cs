namespace SystemForSharingInfoInHospitals.Domain.Events;

public class PatientDeletedEvent : BaseEvent
{
    public Patient Patient { get; set; }
    
    public PatientDeletedEvent(Patient patient)
    {
        Patient = patient;
    }
}
