using Common;
using HospitalManagement.Domain.Events;
using HospitalManagement.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Features.Doctor.Commands;
public record RegisterDoctorCommand : IRequest<int>
{
    public string Name { get; init; } = null!;
    public string? Surname { get; init; }
    public string? Degree { get; init; }
    public int? DepartmentID { get; init; }
}

public class RegisterDoctorController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> RegisterDoctor(RegisterDoctorCommand command)
    {
        return await Mediator.Send(command);
    }
}

public class RegisterDoctorCommandHandler : IRequestHandler<RegisterDoctorCommand, int>
{
    private readonly IHospitalManagementDbContext _context;

    public RegisterDoctorCommandHandler(IHospitalManagementDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(RegisterDoctorCommand request, CancellationToken cancellationToken)
    {
        var entity = new HospitalManagement.Domain.Entities.Doctor
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
