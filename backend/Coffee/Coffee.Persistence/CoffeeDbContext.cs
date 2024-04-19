using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffee.Application.Interfaces;
using Coffee.Domain.Models;
using Coffee.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Persistence;
public sealed class CoffeeDbContext : DbContext, ICoffeeDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Meeting> Coming { get; set; }
    public DbSet<Meeting> Success { get; set; }
    public DbSet<Meeting> Failed { get; set; }

    public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new MeetingConfiguration());
        base.OnModelCreating(builder);
    }
}
