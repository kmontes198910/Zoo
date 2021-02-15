using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Domain;
using Shared.Infrastructure.Services;
using Zoo.Animal.Domain;
using Zoo.Animal.Infrastructure.Persistence;
using Zoo.Shared.Infrastructure.Persistence.EntityFramework;

namespace ZooBackend.Extensions.DependencyInjection
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ZooContext).Assembly);

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IZooAnimalRepository, PgSqlZooAnimalRepository>();

            return services;
        }
    }
}