using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.Entities;
using SystemForSharingInfoInHospitals.Domain.DoctorTreatsPatients.ValueObjects;

namespace SystemForSharingInfoInHospitals.Infrastructure.Data.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.OwnsMany<SpecializedWorkplace>(x => x.SpecializedWorkplaces);
    }
}
