using System.Reflection;
using HospitalManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Data;

public class HospitalManagementDbContext : DbContext, IHospitalManagementDbContext
{
    public HospitalManagementDbContext(DbContextOptions<HospitalManagementDbContext> options) : base(options) { }
    
    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<HoursPerDay> HoursPerDays => Set<HoursPerDay>();

    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
