using System.Reflection;
using Appointments.Infrastructure.Data;
using Ardalis.GuardClauses;
using AutoMapper;
using Common.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Appointments;

public static class DependencyInjection
{
    public static IServiceCollection AddAppointmentsServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AppointmentDefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<AppointmentDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IAppointmentDbContext>(provider => provider.GetRequiredService<AppointmentDbContext>());

        services.AddScoped<AppointmentDbContextInitialiser>();
        
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return services;
    }
}
