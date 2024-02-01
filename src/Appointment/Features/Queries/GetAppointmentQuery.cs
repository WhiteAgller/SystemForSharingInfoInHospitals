using Appointments.Domain.Entities;
using Appointments.Infrastructure.Data;
using Ardalis.GuardClauses;
using AutoMapper;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Features.Queries;

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

public class GetAppointmentQueryHandler(IAppointmentDbContext context, IMapper mapper) : IRequestHandler<GetAppointmentQuery, GetAppointmentDto>
{
    public async Task<GetAppointmentDto> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Appointments.FindAsync(request.AppointmentId);
        Guard.Against.NotFound<Appointment>(request.AppointmentId.ToString(), entity);
        return mapper.Map<Appointment, GetAppointmentDto>(entity);
    }
}
