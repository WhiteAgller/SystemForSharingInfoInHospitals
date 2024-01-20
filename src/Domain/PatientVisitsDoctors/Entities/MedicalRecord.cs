namespace SystemForSharingInfoInHospitals.Domain.Entities;

public class MedicalRecord : BaseAuditableEntity
{
    public int PatientId { get; set; }

    public List<Difficulty> Difficulties { get; set; } = new List<Difficulty>();
}

public class Difficulty
{
    public int DoctorId { get; set; }

    public string Diagnosis { get; set; } = null!;
    
    public string TreatmentPlan { get; set; } = null!;
}

public class MedicalRecordCreate
{
    public List<Difficulty> History { get; set; } = new List<Difficulty>();
}
