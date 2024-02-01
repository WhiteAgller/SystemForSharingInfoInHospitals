using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SpecializedExaminations.Domain.Entities;

namespace SpecializedExaminations.Infrastructure.Data;

public class SpecializedExaminationDbContext : DbContext, ISpecializedExaminationDbContext
{
    public SpecializedExaminationDbContext(DbContextOptions<SpecializedExaminationDbContext> options) : base(options) { }
    
    public DbSet<ExaminationRequest> ExaminationRequests => Set<ExaminationRequest>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(builder);
    }
}
