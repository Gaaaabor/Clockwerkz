using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class PausedTriggerGrpMap : IEntityTypeConfiguration<Domain.Entities.PausedTriggerGrp>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.PausedTriggerGrp> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("PAUSED_TRIGGER_GRPS", "Quartz");

            // key
            builder.HasKey(t => new { t.SchedName, t.TriggerGroup });

            // properties
            builder.Property(t => t.SchedName)
                .IsRequired()
                .HasColumnName("SCHED_NAME")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

            builder.Property(t => t.TriggerGroup)
                .IsRequired()
                .HasColumnName("TRIGGER_GROUP")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            // relationships
            #endregion
        }
    }
}
