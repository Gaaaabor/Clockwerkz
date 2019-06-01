using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class CronTriggerMap
        : IEntityTypeConfiguration<Clockwerkz.Domain.Entities.CronTrigger>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Clockwerkz.Domain.Entities.CronTrigger> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("CRON_TRIGGERS", "Quartz");

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

            builder.Property(t => t.CronExpression)
                .IsRequired()
                .HasColumnName("CRON_EXPRESSION")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

            builder.Property(t => t.TimeZoneId)
                .HasColumnName("TIME_ZONE_ID")
                .HasColumnType("nvarchar(80)")
                .HasMaxLength(80);

            // relationships
            builder.HasOne(t => t.Trigger)
                .WithMany(t => t.CronTriggers)
                .HasForeignKey(d => new { d.SchedName, d.TriggerName, d.TriggerGroup})
                .HasConstraintName("FK_CRON_TRIGGERS_TRIGGERS");

            #endregion
        }

    }
}
