using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemForSharingInfoInHospitals.Domain.Entities;

namespace SystemForSharingInfoInHospitals.Infrastructure.Data.Configurations;

public class MedicalRecordConfiguration: IEntityTypeConfiguration<MedicalRecord>
{
    public void Configure(EntityTypeBuilder<MedicalRecord> builder)
    {
        builder
            .OwnsMany(x => x.Difficulties);
    }
}
