using Microsoft.EntityFrameworkCore;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Infrastructure.Data;

public interface IPatientDbContext
{
    public DbSet<Patient> Patients { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
