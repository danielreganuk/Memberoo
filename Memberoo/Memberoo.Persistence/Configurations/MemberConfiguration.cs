using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Memberoo.Persistence.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(e => e.Active).HasDefaultValue(true);
            builder.Property(e => e.Employee).HasDefaultValue(false);
            builder.Property(e => e.EncodedId).HasComputedColumnSql("[MemberId]" + 100000);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(e => e.LastName).IsRequired();
            builder.Property(e => e.Password).IsRequired();
        }
    }
}