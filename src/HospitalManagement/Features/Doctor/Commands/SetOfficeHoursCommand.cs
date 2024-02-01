using Ardalis.GuardClauses;
using Common;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Features.Doctor.Commands;
public record SetOfficeHoursCommand : IRequest
{
    public int DoctorId { get; set; }
    public IList<HoursPerDay> OfficeHours { get; set; } = new List<HoursPerDay>();
}
public class SetOfficeHoursController : ApiControllerBase
{
    [HttpPut]
    public async Task<ActionResult> ScheudleAppointment(SetOfficeHoursCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}
public class SetOfficeHoursCommandHandler : IRequestHandler<SetOfficeHoursCommand>
{
    private readonly IHospitalManagementDbContext _context;
    public SetOfficeHoursCommandHandler(IHospitalManagementDbContext context)
    {
        _context = context;
    }

    public async Task Handle(SetOfficeHoursCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Doctors
            .FindAsync(new object[] { request.DoctorId }, cancellationToken);

        Guard.Against.NotFound(request.DoctorId, entity);

        entity.OfficeHours = request.OfficeHours;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
