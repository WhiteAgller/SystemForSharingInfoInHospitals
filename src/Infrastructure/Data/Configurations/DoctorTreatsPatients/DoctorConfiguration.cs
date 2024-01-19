using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemForSharingInfoInHospitals.Domain.Entities.DoctorTreatsPatients;

namespace SystemForSharingInfoInHospitals.Infrastructure.Data.Configurations.DoctorTreatsPatients;
public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        
    }
}
