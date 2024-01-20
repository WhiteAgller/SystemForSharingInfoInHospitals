namespace SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.Entities;

public class ResultOfExamination
{
    public int PatientId { get; set; }
    
    public int DoctorId { get; set; }
    
    public int DepartmentId { get; set; }

    public string SpecializedWorkplace { get; set; } = null!;

    public string Result { get; set; } = null!;
}
