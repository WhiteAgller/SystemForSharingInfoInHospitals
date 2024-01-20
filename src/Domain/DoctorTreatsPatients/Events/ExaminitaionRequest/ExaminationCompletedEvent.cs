namespace SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.Events.ExaminitaionRequest;

public class ExaminationCompletedEvent : BaseEvent
{
    public Entities.ExaminationRequest ExaminitaionRequest { get; set; }

    public ExaminationCompletedEvent(Entities.ExaminationRequest examinitaionRequest)
    {
        ExaminitaionRequest = examinitaionRequest;
    }
}
