using Coffee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Data;

public class DataContext : IdentityDbContext<User>
{
    public DbSet<Image> Images { get; set; }
    public DbSet<Theme> Themes { get; set; }
    public DbSet<FutureMeeting> FutureMeetings { get; set; }
    public DbSet<CompletedMeeting> CompletedMeetings { get; set; }
    public DbSet<Room> Rooms { get; set; }

    public string DbPath { get; }

    public DataContext()
    {
        DbPath = "Database/LocalDB.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<IdentityRole> roles = new()
        {
            new()
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
            },
            new()
            {
                Name = "User",
                NormalizedName = "USER",
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}
