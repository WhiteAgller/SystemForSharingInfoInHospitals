using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;

namespace SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.Doctor.Commands;
public record UpdateDoctorCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string? Surname { get; init; }
    public string? Degree { get; init; }
    public int? DepartmentID { get; set; }
}

public class UpdateDoctorController : ApiControllerBase
{
    [HttpPut]
    public async Task<ActionResult> UpdateDoctor(UpdateDoctorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}
public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDoctorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Doctors
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;
        entity.Surname = request.Surname;
        entity.Degree = request.Degree;
        entity.DepartmentId = request.DepartmentID;

        await _context.SaveChangesAsync(cancellationToken);
    }
}

