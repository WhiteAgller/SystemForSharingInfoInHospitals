
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

public class AddDiagnosisCommandHandler(IApplicationDbContext context)
    : IRequestHandler<AddDiagnosisCommand>
{
    public async Task Handle(AddDiagnosisCommand request, CancellationToken cancellationToken)
    {
        var patient = await context.Patients.FindAsync(request.PatientId);
        Guard.Against.NotFound(request.PatientId, patient);
        
        patient.MedicalRecord.History.Add(new History()
        {
            DoctorId = request.DoctorId,
            Diagnosis = request.Diagnosis,
            TreatmentPlan = request.TreatmentPlan,
        });
        
    }
}

