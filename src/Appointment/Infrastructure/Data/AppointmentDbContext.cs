using System.Reflection;
using Appointments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Infrastructure.Data;

public class AppointmentDbContext : DbContext, IAppointmentDbContext
{
    public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) { }
    
    public DbSet<Appointment> Appointments => Set<Appointment>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Entity<Appointment>().ToTable("Appointment");
        base.OnModelCreating(builder);
    }
}
