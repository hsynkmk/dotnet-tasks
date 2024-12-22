using App.Application.Interfaces;
using App.Infrastructure.Persistence;
using App.Infrastructure.Seeders;
using App.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<ICourseSeeder, CourseSeeder>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
