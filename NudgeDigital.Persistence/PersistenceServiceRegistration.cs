using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NudgeDigital.Application.Contracts.Persistence;
using NudgeDigital.Persistence.Extensions;

namespace NudgeDigital.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NudgeDigitalDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "NudgeDigitalDB"));
            services.AddScoped<INudgeDigitalDbContext>(provider => provider.GetService<NudgeDigitalDbContext>());
           
            services.AddHealthChecks().AddDbContextCheck<NudgeDigitalDbContext>();
            return services;
        }
    }
}
