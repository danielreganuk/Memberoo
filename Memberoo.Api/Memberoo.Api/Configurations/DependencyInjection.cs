using Memberoo.Application.Interfaces;
using Memberoo.Persistence;

namespace Memberoo.Api.Configurations;

    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfiguredDbContext(configuration);
            services.AddScoped<IMemberooContext>(s => s.GetService<MemberooContext>());

            return services;
        }
    }

