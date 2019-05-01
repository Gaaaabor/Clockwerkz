using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class QrtzSimpleTriggerMap
        : IEntityTypeConfiguration<Clockwerkz.Domain.Entities.QrtzSimpleTrigger>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Clockwerkz.Domain.Entities.QrtzSimpleTrigger> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("QRTZ_SIMPLE_TRIGGERS", "dbo");

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

            builder.Property(t => t.RepeatCount)
                .IsRequired()
                .HasColumnName("REPEAT_COUNT")
                .HasColumnType("int");

            builder.Property(t => t.RepeatInterval)
                .IsRequired()
                .HasColumnName("REPEAT_INTERVAL")
                .HasColumnType("bigint");

            builder.Property(t => t.TimesTriggered)
                .IsRequired()
                .HasColumnName("TIMES_TRIGGERED")
                .HasColumnType("int");

            // relationships
            builder.HasOne(t => t.QrtzTrigger)
                .WithMany(t => t.QrtzSimpleTriggers)
                .HasForeignKey(d => new { d.SchedName, d.TriggerName, d.TriggerGroup})
                .HasConstraintName("FK_QRTZ_SIMPLE_TRIGGERS_QRTZ_TRIGGERS");

            #endregion
        }

    }
}
