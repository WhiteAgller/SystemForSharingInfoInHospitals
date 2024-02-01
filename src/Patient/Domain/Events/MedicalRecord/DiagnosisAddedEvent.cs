using Common.DomainCommon;

namespace PatientManagement.Domain.Events.MedicalRecord;

public class DiagnosisAddedEvent : BaseEvent
{
    public PatientManagement.Domain.Entities.MedicalRecord MedicalRecord;
    
    public DiagnosisAddedEvent(PatientManagement.Domain.Entities.MedicalRecord medicalRecord)
    {
        MedicalRecord = medicalRecord;
    }
}
