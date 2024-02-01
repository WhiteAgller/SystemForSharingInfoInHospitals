using Ardalis.GuardClauses;
using Common;
using HospitalManagement.Domain.ValueObjects;
using HospitalManagement.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Features.Department.Commands;
public record UpdateDepartmentCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public List<SpecializedWorkplace> SpecializedWorkplaces { get; set; } = new List<SpecializedWorkplace>();
}

public class UpdateDepartmentController : ApiControllerBase
{
    [HttpPut]
    public async Task<ActionResult> UpdateDepartment(UpdateDepartmentCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
{
    private readonly IHospitalManagementDbContext _context;

    public UpdateDepartmentCommandHandler(IHospitalManagementDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Departments
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);
        
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.SpecializedWorkplaces = request.SpecializedWorkplaces;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
