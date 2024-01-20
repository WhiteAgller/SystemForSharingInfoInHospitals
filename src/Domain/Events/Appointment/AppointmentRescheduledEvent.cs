namespace SystemForSharingInfoInHospitals.Domain.Events.Appointment;

public class AppointmentRescheduledEvent : BaseEvent
{
    public Entities.Appointment Appointment { get; set; }
    
    public AppointmentRescheduledEvent(Entities.Appointment appointment)
    {
        Appointment = appointment;
    }
}
