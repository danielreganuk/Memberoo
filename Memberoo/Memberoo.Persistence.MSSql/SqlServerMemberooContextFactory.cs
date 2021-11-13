using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Memberoo.Persistence.SqlServer;

public class SqlServerMemberooContextFactory : IDesignTimeDbContextFactory<SqlServerMemberooContext>
{
    public SqlServerMemberooContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile("appsettings.local.json", true)
            .Build();

        var builder = new DbContextOptionsBuilder<SqlServerMemberooContext>();
        builder.UseSqlServer();

        return new SqlServerMemberooContext(builder.Options);
    }
}