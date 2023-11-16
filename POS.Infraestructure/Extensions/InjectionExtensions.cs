using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Infraestructure.Persistences.Context;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Infraestructure.Persistences.Repositories;

namespace POS.Infraestructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(PosContext).Assembly.FullName;

            services.AddDbContext<PosContext>(options =>
                options.UseSqlServer(
                        configuration.GetConnectionString("POSConnection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
