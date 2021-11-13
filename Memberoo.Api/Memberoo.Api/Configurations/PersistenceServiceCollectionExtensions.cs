using Memberoo.Persistence.SqlServer;

namespace Memberoo.Api.Configurations;

public static class PersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddConfiguredDbContext(this IServiceCollection serviceCollection, IConfiguration config)
    {
        var persistenceConfig = config?.GetSection("Persistence")?.Get<PersistenceConfiguration>();

        if (persistenceConfig?.Provider.ToUpper() == "SQLSERVER")
        {
            serviceCollection.AddSqlServerDbContext(config);
        }

        return serviceCollection;
    }
}

public class PersistenceConfiguration
{
    public string Provider { get; set; }
}