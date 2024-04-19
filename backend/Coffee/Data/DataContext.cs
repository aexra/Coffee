using Coffee.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Meeting> ComingMeetings { get; set; }
    public DbSet<Meeting> SuccessMeetings { get; set; }
    public DbSet<Meeting> FailedMeetings { get; set; }
    
    public DataContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
