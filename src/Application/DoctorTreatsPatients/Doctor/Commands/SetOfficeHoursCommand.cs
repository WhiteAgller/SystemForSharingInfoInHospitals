using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.Entities;
using SystemForSharingInfoInHospitals.Domain.Entities.DoctorTreatsPatients;

namespace SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.Commands.UpdateDoctor;
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
    private readonly IApplicationDbContext _context;
    public SetOfficeHoursCommandHandler(IApplicationDbContext context)
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
