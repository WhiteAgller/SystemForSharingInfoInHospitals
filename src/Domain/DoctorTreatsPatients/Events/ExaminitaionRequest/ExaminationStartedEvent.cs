namespace SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.Events.ExaminitaionRequest;

public class ExaminationStartedEvent : BaseEvent
{
    public Entities.ExaminationRequest ExaminitaionRequest { get; set; }

    public ExaminationStartedEvent(Entities.ExaminationRequest examinitaionRequest)
    {
        ExaminitaionRequest = examinitaionRequest;
    }
}
