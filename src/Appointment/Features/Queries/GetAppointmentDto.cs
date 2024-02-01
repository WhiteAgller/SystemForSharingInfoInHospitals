using Appointments.Domain.Entities;
using Appointments.Domain.Enums;
using AutoMapper;

namespace Appointments.Features.Queries;

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
