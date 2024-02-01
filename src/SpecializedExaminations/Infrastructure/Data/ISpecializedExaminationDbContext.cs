using Microsoft.EntityFrameworkCore;
using SpecializedExaminations.Domain.Entities;

namespace SpecializedExaminations.Infrastructure.Data;

public interface ISpecializedExaminationDbContext
{
    public DbSet<ExaminationRequest> ExaminationRequests { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
