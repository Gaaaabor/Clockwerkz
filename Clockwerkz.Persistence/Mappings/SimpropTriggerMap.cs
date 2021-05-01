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
                .HasField("SCHED_NAME")
                .HasMaxLength(120);

            builder.Property(t => t.TriggerName)
                .IsRequired()
                .HasField("TRIGGER_NAME")

                .HasMaxLength(150);

            builder.Property(t => t.TriggerGroup)
                .IsRequired()
                .HasField("TRIGGER_GROUP")

                .HasMaxLength(150);

            builder.Property(t => t.StrProp1)
                .HasField("STR_PROP_1")

                .HasMaxLength(512);

            builder.Property(t => t.StrProp2)
                .HasField("STR_PROP_2")

                .HasMaxLength(512);

            builder.Property(t => t.StrProp3)
                .HasField("STR_PROP_3")

                .HasMaxLength(512);

            builder.Property(t => t.IntProp1)
                .HasField("INT_PROP_1")
                ;

            builder.Property(t => t.IntProp2)
                .HasField("INT_PROP_2")
                ;

            builder.Property(t => t.LongProp1)
                .HasField("LONG_PROP_1")
                ;

            builder.Property(t => t.LongProp2)
                .HasField("LONG_PROP_2")
                ;

            builder.Property(t => t.DecProp1)
                .HasField("DEC_PROP_1")
                .HasColumnType("numeric(13, 4)");

            builder.Property(t => t.DecProp2)
                .HasField("DEC_PROP_2")
                .HasColumnType("numeric(13, 4)");

            builder.Property(t => t.BoolProp1)
                .HasField("BOOL_PROP_1")
                .HasColumnType("bit");

            builder.Property(t => t.BoolProp2)
                .HasField("BOOL_PROP_2")
                .HasColumnType("bit");

            builder.Property(t => t.TimeZoneId)
                .HasField("TIME_ZONE_ID")
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
