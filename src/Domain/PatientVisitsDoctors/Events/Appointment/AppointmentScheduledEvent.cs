namespace SystemForSharingInfoInHospitals.Domain.Events.Appointment;

public class AppointmentScheduledEvent : BaseEvent
{
    public Entities.Appointment Appointment { get; set; }
    public AppointmentScheduledEvent(Entities.Appointment appointment)
    {
        Appointment = appointment;
    }
}
