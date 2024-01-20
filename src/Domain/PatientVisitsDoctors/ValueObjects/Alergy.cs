namespace SystemForSharingInfoInHospitals.Domain.ValueObjects;

public class Alergy : ValueObject
{
    public int PatientId { get; set; }
    public string Name { set; get; }
    
    public Alergy(string name)
    {
        Name = name;
    }

    public static Alergy HayFever => new (nameof(HayFever));
    public static Alergy AllergicAsthma => new (nameof(AllergicAsthma));
    public static Alergy FoodAllergie => new (nameof(FoodAllergie));
    public static Alergy AllergicConjunctivitis => new (nameof(AllergicConjunctivitis));
    public static Alergy InsectAllergy => new (nameof(InsectAllergy));
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}
