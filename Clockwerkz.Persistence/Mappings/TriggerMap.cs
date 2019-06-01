using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class TriggerMap
        : IEntityTypeConfiguration<Clockwerkz.Domain.Entities.Trigger>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Clockwerkz.Domain.Entities.Trigger> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("TRIGGERS", "Quartz");

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

            builder.Property(t => t.JobName)
                .IsRequired()
                .HasColumnName("JOB_NAME")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.JobGroup)
                .IsRequired()
                .HasColumnName("JOB_GROUP")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("nvarchar(250)")
                .HasMaxLength(250);

            builder.Property(t => t.NextFireTime)
                .HasColumnName("NEXT_FIRE_TIME")
                .HasColumnType("bigint");

            builder.Property(t => t.PrevFireTime)
                .HasColumnName("PREV_FIRE_TIME")
                .HasColumnType("bigint");

            builder.Property(t => t.Priority)
                .HasColumnName("PRIORITY")
                .HasColumnType("int");

            builder.Property(t => t.TriggerState)
                .IsRequired()
                .HasColumnName("TRIGGER_STATE")
                .HasColumnType("nvarchar(16)")
                .HasMaxLength(16);

            builder.Property(t => t.TriggerType)
                .IsRequired()
                .HasColumnName("TRIGGER_TYPE")
                .HasColumnType("nvarchar(8)")
                .HasMaxLength(8);

            builder.Property(t => t.StartTime)
                .IsRequired()
                .HasColumnName("START_TIME")
                .HasColumnType("bigint");

            builder.Property(t => t.EndTime)
                .HasColumnName("END_TIME")
                .HasColumnType("bigint");

            builder.Property(t => t.CalendarName)
                .HasColumnName("CALENDAR_NAME")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.MisfireInstr)
                .HasColumnName("MISFIRE_INSTR")
                .HasColumnType("int");

            builder.Property(t => t.JobData)
                .HasColumnName("JOB_DATA")
                .HasColumnType("varbinary(max)");

            // relationships
            builder.HasOne(t => t.JobDetail)
                .WithMany(t => t.Triggers)
                .HasForeignKey(d => new { d.SchedName, d.JobName, d.JobGroup})
                .HasConstraintName("FK_TRIGGERS_JOB_DETAILS");

            #endregion
        }

    }
}
