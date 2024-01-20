namespace SystemForSharingInfoInHospitals.Domain.Events.MedicalRecord;

public class DiagnosisAddedEvent : BaseEvent
{
    public Entities.MedicalRecord MedicalRecord;
    
    public DiagnosisAddedEvent(Entities.MedicalRecord medicalRecord)
    {
        MedicalRecord = medicalRecord;
    }
}
