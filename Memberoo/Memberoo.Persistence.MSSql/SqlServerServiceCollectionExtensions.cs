using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Memberoo.Persistence.SqlServer
{
    public static class SqlServerServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServerDbContext(this IServiceCollection serviceCollection,
            IConfiguration config = null)
        {
            Console.WriteLine($"Connection: {config.GetConnectionString("DbContext")}");
            var connectionString = config.GetConnectionString("DbContext");
            serviceCollection.AddDbContext<MemberooContext, SqlServerMemberooContext>(opts =>
            {
                opts.UseSqlServer(
                    connectionString,
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("Memberoo.Persistence.SqlServer");
                    });
            });

            return serviceCollection;
        }
    }
}