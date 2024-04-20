using Coffee.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
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
}
