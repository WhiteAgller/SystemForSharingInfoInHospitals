using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Events.Patient;
using PatientManagement.Domain.ValueObjects;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Features.Patients.Commands;

public record RegisterPatientCommand : IRequest<int>
{
    public string Name { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public IEnumerable<Alergy> Alergies { get; set; } = new List<Alergy>();

    public MedicalRecordCreate MedicalRecordCreate { get; set; } = new();
}

public class RegisterPatientController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> RegisterPatient(RegisterPatientCommand command)
    {
        return await Mediator.Send(command);
    }
}

public class RegisterPatientCommandHandler(IPatientManagementDbContext context) : IRequestHandler<RegisterPatientCommand, int>
{
    public async Task<int> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
    {
        var entity = new Patient()
        {
            Name = request.Name,
            MedicalRecord = new MedicalRecord()
            {   
               Difficulties = new List<Difficulty>()
            },
            DateOfBirth = request.DateOfBirth,
            Alergies = request.Alergies,
        };
        
        entity.AddDomainEvent(new PatientRegisteredEvent(entity));

        context.Patients.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
