namespace SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.Events.ExaminitaionRequest;

public class ExaminationRequestedEvent : BaseEvent
{
    public Entities.ExaminationRequest ExaminitaionRequest { get; set; }

    public ExaminationRequestedEvent(Entities.ExaminationRequest examinitaionRequest)
    {
        ExaminitaionRequest = examinitaionRequest;
    }
}
