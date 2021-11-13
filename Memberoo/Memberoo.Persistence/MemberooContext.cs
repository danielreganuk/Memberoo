using Memberoo.Application.Interfaces;

namespace Memberoo.Persistence;

public class MemberooContext : DbContext, IMemberooContext
{
    public MemberooContext()
    {
    }

    public MemberooContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = "TODO";
                    entry.Entity.LastModified = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.ApplyConfigurationsFromAssembly(typeof(MemberooContext).Assembly);
    }
}