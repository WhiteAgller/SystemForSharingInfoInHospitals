using Appointments.Domain.Enums;
using Common.DomainCommon;


namespace Appointments.Domain.Entities;

public class Appointment : BaseAuditableEntity
{
    public int PatientId { get; set; }
    
    public int DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }
    
    public Status Status { get; set; }

}
