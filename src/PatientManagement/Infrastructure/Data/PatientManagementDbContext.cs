using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Infrastructure.Data;

public class PatientManagementDbContext : DbContext, IPatientManagementDbContext
{
    public PatientManagementDbContext(DbContextOptions<PatientManagementDbContext> options) : base(options) { }
    
    public DbSet<Patient> Patients => Set<Patient>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(builder);
    }
}
