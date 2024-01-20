namespace SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.Events.ExaminitaionRequest;

public class ExaminationAssignedEvent : BaseEvent
{
    public Entities.ExaminationRequest ExaminitaionRequest { get; set; }

    public ExaminationAssignedEvent(Entities.ExaminationRequest examinitaionRequest)
    {
        ExaminitaionRequest = examinitaionRequest;
    }
}
