using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Application.Common.Mappings;
using SystemForSharingInfoInHospitals.Application.Common.Models;
using SystemForSharingInfoInHospitals.Domain.Entities;

namespace SystemForSharingInfoInHospitals.Application.Patients.Queries;

public record GetPatientQuery : IRequest<GetPatientDto>
{
    public int PatientId { get; init; }
    
}

public class PatientGetController : ApiControllerBase
{
    [HttpGet]
    public async Task<GetPatientDto> GetPatient([FromQuery]GetPatientQuery query)
    {
        return await Mediator.Send(query);
    }
}

public class GetPatientQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetPatientQuery, GetPatientDto>
{
    public async Task<GetPatientDto> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Patients.FindAsync(request.PatientId);
        Guard.Against.NotFound(request.PatientId, entity);
        return mapper.Map<Patient, GetPatientDto>(entity);
    }
}
