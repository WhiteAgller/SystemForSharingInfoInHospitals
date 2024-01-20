using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.ValueObjects;
using SystemForSharingInfoInHospitals.Domain.Events.DoctorTreatsPatients;

namespace SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.Department.Commands;
public record CreateDepartmentCommand : IRequest<int>
{
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public List<SpecializedWorkplace> SpecializedWorkplaces { get; set; } = new List<SpecializedWorkplace>();
}

public class CreateDepartmentController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> ScheudleAppointment(CreateDepartmentCommand command)
    {
        return await Mediator.Send(command);
    }
}

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.DoctorTreatsPatients.Entities.Department()
        {
            Name = request.Name,
            Description = request.Description,
            SpecializedWorkplaces = request.SpecializedWorkplaces
        };

        entity.AddDomainEvent(new DepartmentCreatedEvent(entity));
        
        _context.Departments.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
