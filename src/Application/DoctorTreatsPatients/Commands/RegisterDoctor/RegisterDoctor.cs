using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Domain.Entities.DoctorTreatsPatients;
using SystemForSharingInfoInHospitals.Domain.Events.DoctorTreatsPatients;

namespace SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.Commands.RegisterDoctor;
public record RegisterDoctorCommand : IRequest<int>
{
    public string? Name { get; init; }
    public string? Surname { get; init; }
    public string? Degree { get; init; }
}

public class RegisterDoctorCommandHandler : IRequestHandler<RegisterDoctorCommand, int>
{
    private readonly IApplicationDbContext _context;

    public RegisterDoctorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(RegisterDoctorCommand request, CancellationToken cancellationToken)
    {
        var entity = new Doctor
        {
            Name = request.Name,
            Surname = request.Surname,
            Degree = request.Degree
        };

        entity.AddDomainEvent(new DoctorRegisteredEvent(entity));

        _context.Doctors.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
