namespace SystemForSharingInfoInHospitals.Domain.Events.Appointment;

public class AppointmentCancelledEvent : BaseEvent
{
    public Entities.Appointment Appointment { get; set; }
    
    public AppointmentCancelledEvent(Entities.Appointment appointment)
    {
        Appointment = appointment;
    }
}
