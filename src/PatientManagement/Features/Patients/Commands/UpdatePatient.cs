using Ardalis.GuardClauses;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.ValueObjects;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Features.Patients.Commands;

public record UpdatePatientCommand : IRequest
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public IEnumerable<Alergy> Alergies { get; set; } = new List<Alergy>();

    public MedicalRecord MedicalRecord { get; set; } = new();
}

public class UpdatePatientController : ApiControllerBase
{
    [HttpPut]
    public async Task<ActionResult> UpdatePatient(UpdatePatientCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}

public class UpdatePatientCommandHandler(IPatientManagementDbContext context) : IRequestHandler<UpdatePatientCommand>
{
    public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Patients.FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Alergies = request.Alergies;
        entity.Name = request.Name;
        entity.MedicalRecord = request.MedicalRecord;
        entity.DateOfBirth = request.DateOfBirth;

        await context.SaveChangesAsync(cancellationToken);
    }
}
