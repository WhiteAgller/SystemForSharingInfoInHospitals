using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Application.Common.Mappings;
using SystemForSharingInfoInHospitals.Application.Common.Models;

namespace SystemForSharingInfoInHospitals.Application.Appointments.Queries;

public record GetAppointmentsForPatientQuery : IRequest<PaginatedList<GetAppointmentDto>>
{
    public int PatientId { get; set; } 
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class AppointmetGetAllController : ApiControllerBase
{
    [HttpGet]
    public async Task<PaginatedList<GetAppointmentDto>> GetAllAppointmentsForPatient([FromQuery]GetAppointmentsForPatientQuery query)
    {
        return await Mediator.Send(query);
    }
}

public class GetAppointmentsForPatientQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetAppointmentsForPatientQuery, PaginatedList<GetAppointmentDto>>
{
    public async Task<PaginatedList<GetAppointmentDto>> Handle(GetAppointmentsForPatientQuery request, CancellationToken cancellationToken)
    {
        return await context.Appointments
            .Where(x => x.PatientId == request.PatientId)
            .OrderBy(x => x.AppointmentDate)
            .ProjectTo<GetAppointmentDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
