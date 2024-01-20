namespace SystemForSharingInfoInHospitals.Domain.Entities;

public class MedicalRecord : BaseAuditableEntity
{
    public int PatientId { get; set; }
    
    public int DoctorId { get; set; }

    public string Diagnosis { get; set; } = null!;

    public string TreatmentPlan { get; set; } = null!;
}

public class MedicalRecordCreate
{
    public int DoctorId { get; set; }
    public string Diagnosis { get; set; } = null!;

    public string TreatmentPlan { get; set; } = null!;
}
