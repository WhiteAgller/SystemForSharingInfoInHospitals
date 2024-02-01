using Ardalis.GuardClauses;
using Common.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement;

public static class DependencyInjection
{
    public static IServiceCollection AddPatientManagementServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PatientManagementDefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<PatientManagementDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IPatientManagementDbContext>(provider => provider.GetRequiredService<PatientManagementDbContext>());

        services.AddScoped<PatientManagementDbContextInitialiser>();
        
        return services;
    }
}
