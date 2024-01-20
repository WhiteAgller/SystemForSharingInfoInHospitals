using SystemForSharingInfoInHospitals.Domain.Entities;
using SystemForSharingInfoInHospitals.Domain.ValueObjects;

namespace SystemForSharingInfoInHospitals.Application.Patients.Queries;

public class GetPatientDto
{
    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }
    public IEnumerable<Alergy> Alergies { get; set; } = new List<Alergy>();

    public MedicalRecord MedicalRecord { get; set; } = new();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Patient, GetPatientDto>()
                .ForMember(x => x.Alergies, opt => opt.MapFrom(y => y.Alergies.ToArray()));
        }
    }
}

