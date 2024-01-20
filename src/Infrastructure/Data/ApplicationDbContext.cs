using System.Reflection;
using SystemForSharingInfoInHospitals.Application.Common.Interfaces;
using SystemForSharingInfoInHospitals.Domain.Entities;
using SystemForSharingInfoInHospitals.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SystemForSharingInfoInHospitals.Domain.Entities.DoctorTreatsPatients;

namespace SystemForSharingInfoInHospitals.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<HoursPerDay> HoursPerDays => Set<HoursPerDay>();

    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
