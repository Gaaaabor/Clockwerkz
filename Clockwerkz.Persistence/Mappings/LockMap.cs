using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class LockMap : IEntityTypeConfiguration<Domain.Entities.Lock>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.Lock> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("LOCKS", "Quartz");

            // key
            builder.HasKey(t => new { t.SchedName, t.LockName });

            // properties
            builder.Property(t => t.SchedName)
                .IsRequired()
                .HasColumnName("SCHED_NAME")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

            builder.Property(t => t.LockName)
                .IsRequired()
                .HasColumnName("LOCK_NAME")
                .HasColumnType("nvarchar(40)")
                .HasMaxLength(40);

            // relationships
            #endregion
        }
    }
}
