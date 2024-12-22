using App.Application.Interfaces;
using App.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICourseService, CourseService>();
    }
}