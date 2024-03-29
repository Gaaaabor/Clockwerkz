using Clockwerkz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class SimpropTriggerMap : IEntityTypeConfiguration<SimpropTrigger>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SimpropTrigger> builder)
        {
            #region Generated Configure            
            // table
            builder.ToTable("SIMPROP_TRIGGERS", "Quartz");

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

            builder.Property(t => t.StrProp1)
                .HasColumnName("STR_PROP_1")
                .HasColumnType("nvarchar(512)")
                .HasMaxLength(512);

            builder.Property(t => t.StrProp2)
                .HasColumnName("STR_PROP_2")
                .HasColumnType("nvarchar(512)")
                .HasMaxLength(512);

            builder.Property(t => t.StrProp3)
                .HasColumnName("STR_PROP_3")
                .HasColumnType("nvarchar(512)")
                .HasMaxLength(512);

            builder.Property(t => t.IntProp1)
                .HasColumnName("INT_PROP_1");

            builder.Property(t => t.IntProp2)
                .HasColumnName("INT_PROP_2");

            builder.Property(t => t.LongProp1)
                .HasColumnName("LONG_PROP_1");

            builder.Property(t => t.LongProp2)
                .HasColumnName("LONG_PROP_2");

            builder.Property(t => t.DecProp1)
                .HasColumnName("DEC_PROP_1")
                .HasColumnType("numeric(13, 4)");

            builder.Property(t => t.DecProp2)
                .HasColumnName("DEC_PROP_2")
                .HasColumnType("numeric(13, 4)");

            builder.Property(t => t.BoolProp1)
                .HasColumnName("BOOL_PROP_1")
                .HasColumnType("bit");

            builder.Property(t => t.BoolProp2)
                .HasColumnName("BOOL_PROP_2")
                .HasColumnType("bit");

            builder.Property(t => t.TimeZoneId)
                .HasColumnName("TIME_ZONE_ID")
                .HasColumnType("nvarchar(80)")
                .HasMaxLength(80);

            // relationships
            builder.HasOne(t => t.Trigger)
                .WithOne(p => p.SimpropTrigger)
                .HasForeignKey<SimpropTrigger>(d => new { d.SchedName, d.TriggerName, d.TriggerGroup })
                .HasConstraintName("FK_SIMPROP_TRIGGERS_TRIGGERS");

            #endregion
        }
    }
}
