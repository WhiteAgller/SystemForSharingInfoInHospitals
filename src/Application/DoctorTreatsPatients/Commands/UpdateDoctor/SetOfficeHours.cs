using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Domain.Entities.DoctorTreatsPatients;

namespace SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.Commands.UpdateDoctor;
public record SetOfficeHoursCommand : IRequest
{
    public int DoctorId { get; set; }
    public IList<HoursPerDay> OfficeHours { get; set; } = new List<HoursPerDay>();
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
