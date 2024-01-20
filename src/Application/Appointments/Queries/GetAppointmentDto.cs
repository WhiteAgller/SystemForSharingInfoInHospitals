using SystemForSharingInfoInHospitals.Domain.Entities;
using SystemForSharingInfoInHospitals.Domain.Enums;

namespace SystemForSharingInfoInHospitals.Application.Appointments.Queries;

public class GetAppointmentDto
{
    public int PatientId { get; set; }
    
    public int DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }
    
    public Status Status { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Appointment, GetAppointmentDto>();
        }
    }
}
