using Microsoft.Extensions.DependencyInjection.Patients.Queries;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Application.Common.Mappings;
using SystemForSharingInfoInHospitals.Application.Common.Models;

namespace SystemForSharingInfoInHospitals.Application.Patients.Queries;

public record GetPatientsQuery : IRequest<PaginatedList<GetPatientDto>>
{
    public int PatientId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetPatientsQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetPatientsQuery, PaginatedList<GetPatientDto>>
{
    public async Task<PaginatedList<GetPatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        return await context.Patients
            .Where(x => x.Id == request.PatientId)
            .OrderBy(x => x.Name)
            .ProjectTo<GetPatientDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
