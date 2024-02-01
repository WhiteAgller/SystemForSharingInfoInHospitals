using Common.DomainCommon;

namespace Appointments.Domain.Events;

public class AppointmentRescheduledEvent : BaseEvent
{
    public Entities.Appointment Appointment { get; set; }
    
    public AppointmentRescheduledEvent(Entities.Appointment appointment)
    {
        Appointment = appointment;
    }
}
