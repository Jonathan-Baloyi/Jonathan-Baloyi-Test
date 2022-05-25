using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application layer
            services.AddScoped<IStudentService, StudentService>();

            // Data layer
            services.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}
