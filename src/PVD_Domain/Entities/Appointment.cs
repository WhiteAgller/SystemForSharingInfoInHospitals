using System.ComponentModel.DataAnnotations.Schema;

namespace SystemForSharingInfoInHospitals.Domain.Entities;

public class Appointment : BaseAuditableEntity
{
    public int PatientId { get; set; }

    [ForeignKey(nameof(PatientId))] public virtual Patient Patient { get; set; } = null!;
    
    public int DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }
    
    public Status Status { get; set; }

}
