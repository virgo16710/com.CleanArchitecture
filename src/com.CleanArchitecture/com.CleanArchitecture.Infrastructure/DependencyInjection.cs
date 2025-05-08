using com.CleanArchitecture.Application.Abstractions.Clock;
using com.CleanArchitecture.Application.Abstractions.Data;
using com.CleanArchitecture.Application.Abstractions.Email;
using com.CleanArchitecture.Domain.Abstractions;
using com.CleanArchitecture.Domain.Alquileres;
using com.CleanArchitecture.Domain.Users;
using com.CleanArchitecture.Domain.Vehiculos;
using com.CleanArchitecture.Infrastructure.Clock;
using com.CleanArchitecture.Infrastructure.Data;
using com.CleanArchitecture.Infrastructure.Email;
using com.CleanArchitecture.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace com.CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddTransient<IDatetimeProvider, DatetimeProvider>();
            services.AddTransient<IEmailService, EmailService>();

            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAlquilerRepository, AlquilerRepository>();
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
            SqlMapper.AddTypeHandler<DateOnly>(new DateOnlyTypeHandler());
            return services;
        }
    }
}
