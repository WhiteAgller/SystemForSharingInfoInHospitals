using Common.DomainCommon;

namespace Appointments.Domain.Events;

public class AppointmentScheduledEvent : BaseEvent
{
    public Entities.Appointment Appointment { get; set; }
    public AppointmentScheduledEvent(Entities.Appointment appointment)
    {
        Appointment = appointment;
    }
}
