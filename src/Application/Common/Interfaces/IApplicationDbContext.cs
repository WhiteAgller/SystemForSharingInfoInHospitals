using SystemForSharingInfoInHospitals.Domain.Entities;

namespace SystemForSharingInfoInHospitals.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Doctor> Doctors { get; }
    DbSet<HoursPerDay> HoursPerDays { get; }
    DbSet<Department> Departments { get; }

    DbSet<Patient> Patients { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
