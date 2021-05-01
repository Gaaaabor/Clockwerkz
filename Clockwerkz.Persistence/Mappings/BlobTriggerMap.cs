using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class BlobTriggerMap : IEntityTypeConfiguration<Domain.Entities.BlobTrigger>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.BlobTrigger> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("BLOB_TRIGGERS", "Quartz");

            // key
            builder.HasKey(t => new { t.SchedName, t.TriggerName, t.TriggerGroup });

            // properties
            builder.Property(t => t.SchedName)
                .IsRequired()
                .HasColumnName("SCHED_NAME")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

            builder.Property(t => t.TriggerName)
                .IsRequired()
                .HasColumnName("TRIGGER_NAME")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.TriggerGroup)
                .IsRequired()
                .HasColumnName("TRIGGER_GROUP")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.BlobData)
                .HasColumnName("BLOB_DATA")
                .HasColumnType("varbinary(max)");

            // relationships
            #endregion
        }

    }
}
