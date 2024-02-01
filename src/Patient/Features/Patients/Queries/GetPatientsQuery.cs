using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common;
using Common.Mappings;
using Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Features.Patients.Queries;

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

public class GetPatientsQueryHandler(IPatientDbContext context, IMapper mapper) : IRequestHandler<GetPatientsQuery, PaginatedList<GetPatientDto>>
{
    public async Task<PaginatedList<GetPatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        return await context.Patients
            .OrderBy(x => x.Name)
            .ProjectTo<GetPatientDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
