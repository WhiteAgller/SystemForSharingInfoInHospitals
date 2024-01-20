﻿using SystemForSharingInfoInHospitals.Domain.Entities;
using SystemForSharingInfoInHospitals.Domain.Entities.DoctorTreatsPatients;

namespace SystemForSharingInfoInHospitals.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Doctor> Doctors { get; }
    DbSet<HoursPerDay> HoursPerDays { get; }
    DbSet<Department> Departments { get; }

    DbSet<Patient> Patients { get; }
    
    DbSet<Appointment> Appointments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
