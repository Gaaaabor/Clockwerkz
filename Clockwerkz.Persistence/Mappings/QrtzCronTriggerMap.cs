using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class QrtzCronTriggerMap
        : IEntityTypeConfiguration<Clockwerkz.Domain.Entities.QrtzCronTrigger>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Clockwerkz.Domain.Entities.QrtzCronTrigger> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("QRTZ_CRON_TRIGGERS", "dbo");

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
            builder.HasOne(t => t.QrtzTrigger)
                .WithMany(t => t.QrtzCronTriggers)
                .HasForeignKey(d => new { d.SchedName, d.TriggerName, d.TriggerGroup})
                .HasConstraintName("FK_QRTZ_CRON_TRIGGERS_QRTZ_TRIGGERS");

            #endregion
        }

    }
}
