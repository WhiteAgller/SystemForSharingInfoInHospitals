using Appointments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Infrastructure.Data;

public interface IAppointmentDbContext
{
    DbSet<Appointment> Appointments { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
