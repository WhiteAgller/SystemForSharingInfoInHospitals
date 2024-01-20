using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Application.Patients.Queries;
using SystemForSharingInfoInHospitals.Domain.Entities;
using SystemForSharingInfoInHospitals.Domain.Enums;

namespace SystemForSharingInfoInHospitals.Application.Appointments.Queries;

public record GetAppointmentQuery : IRequest<GetAppointmentDto>
{
    public int AppointmentId { get; set; }
}

public class AppointmentGetController : ApiControllerBase
{
    [HttpGet]
    public async Task<GetAppointmentDto> GetPatient([FromQuery]GetAppointmentQuery query)
    {
        return await Mediator.Send(query);
    }
}

public class GetAppointmentQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetAppointmentQuery, GetAppointmentDto>
{
    public async Task<GetAppointmentDto> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Appointments.FindAsync(request.AppointmentId);
        Guard.Against.NotFound<Appointment>(request.AppointmentId.ToString(), entity);
        return mapper.Map<Appointment, GetAppointmentDto>(entity);
    }
}
