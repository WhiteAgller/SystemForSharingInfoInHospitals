using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Application.Common.Mappings;
using SystemForSharingInfoInHospitals.Application.Common.Models;

namespace SystemForSharingInfoInHospitals.Application.Patients.Queries;

public record GetPatientsQuery : IRequest<PaginatedList<GetPatientDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class PatientGetAllController : ApiControllerBase
{
    [HttpGet]
    public async Task<PaginatedList<GetPatientDto>> GetAllPatients([FromQuery]GetPatientsQuery query)
    {
        return await Mediator.Send(query);
    }
}

public class GetPatientsQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetPatientsQuery, PaginatedList<GetPatientDto>>
{
    public async Task<PaginatedList<GetPatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        return await context.Patients
            .OrderBy(x => x.Name)
            .ProjectTo<GetPatientDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
