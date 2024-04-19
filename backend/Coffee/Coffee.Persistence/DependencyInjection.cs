using Coffee.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coffee.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<CoffeeDbContext>(options => options.UseSqlite(connectionString));
        services.AddScoped<ICoffeeDbContext>(provider => provider.GetService<CoffeeDbContext>());
        return services;
    }
}
