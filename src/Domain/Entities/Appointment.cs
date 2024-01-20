namespace SystemForSharingInfoInHospitals.Domain.Entities;

public class Appointment
{
    public Patient Patient { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }
    
    public Status Status { get; set; }

}
