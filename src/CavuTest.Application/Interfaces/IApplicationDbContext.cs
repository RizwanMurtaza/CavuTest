using CavuTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CavuTest.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<BookingEntity> BookingEntities { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
