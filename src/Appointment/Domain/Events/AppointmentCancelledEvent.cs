using Common.DomainCommon;

namespace Appointments.Domain.Events;

public class AppointmentCancelledEvent : BaseEvent
{
    public Entities.Appointment Appointment { get; set; }
    
    public AppointmentCancelledEvent(Entities.Appointment appointment)
    {
        Appointment = appointment;
    }
}
