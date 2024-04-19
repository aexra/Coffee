using Coffee.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Application.Interfaces;

public interface ICoffeeDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Meeting> Coming { get; set; }
    DbSet<Meeting> Success { get; set; }
    DbSet<Meeting> Failed { get; set; }
    

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
