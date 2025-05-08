using com.CleanArchitecture.Application.Abstractions.Behaviors;
using com.CleanArchitecture.Domain.Alquileres;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
namespace com.CleanArchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuracion =>
            {
                configuracion.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                configuracion.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuracion.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            // Resolver el error CS1061 agregando la directiva using correcta
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddTransient<PrecioService>();
            return services;
        }
    }
}
