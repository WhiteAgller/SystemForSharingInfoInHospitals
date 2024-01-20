namespace SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.ValueObjects;

public class SpecializedWorkplace
{
    public string Name { get; set; }

    public SpecializedWorkplace(string name)
    {
        Name = name;
    }
    
}
