using Microsoft.EntityFrameworkCore;

namespace Memberoo.Persistence.SqlServer
{
    public class SqlServerMemberooContext : MemberooContext
    {
        public SqlServerMemberooContext(DbContextOptions options) : base(options)
        {
        }
    }
}