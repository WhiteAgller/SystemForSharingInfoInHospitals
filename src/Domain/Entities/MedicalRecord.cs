namespace SystemForSharingInfoInHospitals.Domain.Entities;

public class MedicalRecord : BaseAuditableEntity
{
    public int PatientId { get; set; }

    public List<History> History { get; set; } = new List<History>();

}

public class History
{
    public int DoctorId { get; set; }

    public string Diagnosis { get; set; } = null!;

    public string TreatmentPlan { get; set; } = null!;
}

public class MedicalRecordCreate
{
    public List<History> History { get; set; } = new List<History>();
}
