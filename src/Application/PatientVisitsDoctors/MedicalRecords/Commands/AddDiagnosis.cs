
using Microsoft.AspNetCore.Mvc;
using SystemForSharingInfoInHospitals.Application.Common;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Domain.Entities;

namespace SystemForSharingInfoInHospitals.Application.MedicalRecords.Commands;

public record AddDiagnosisCommand : IRequest
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public string Diagnosis { get; set; } = null!;
    public string TreatmentPlan { get; set; } = null!;
}

public class AddDiagnosisController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddDiagnosis(AddDiagnosisCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}

public class AddDiagnosisCommandHandler(IApplicationDbContext context)
    : IRequestHandler<AddDiagnosisCommand>
{
    public async Task Handle(AddDiagnosisCommand request, CancellationToken cancellationToken)
    {
        var patient = await context.Patients.FindAsync(request.PatientId);
        Guard.Against.NotFound(request.PatientId, patient);
        
        patient.MedicalRecord.Difficulties.Add(new Difficulty()
        {
            DoctorId = request.DoctorId,
            Diagnosis = request.Diagnosis,
            TreatmentPlan = request.TreatmentPlan,
        });
        
    }
}

