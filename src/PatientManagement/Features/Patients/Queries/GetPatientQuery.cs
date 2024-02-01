using Ardalis.GuardClauses;
using AutoMapper;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Domain.Entities;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Features.Patients.Queries;

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

public class GetPatientQueryHandler(IPatientManagementDbContext context, IMapper mapper) : IRequestHandler<GetPatientQuery, GetPatientDto>
{
    public async Task<GetPatientDto> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Patients.FindAsync(request.PatientId);
        Guard.Against.NotFound(request.PatientId, entity);
        return mapper.Map<Patient, GetPatientDto>(entity);
    }
}
