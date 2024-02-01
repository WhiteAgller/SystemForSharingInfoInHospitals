using HospitalManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Data;

public interface IHospitalDbContext
{
    public DbSet<Doctor> Doctors { get; }

    public DbSet<HoursPerDay> HoursPerDays { get; }

    public DbSet<Department> Departments { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
