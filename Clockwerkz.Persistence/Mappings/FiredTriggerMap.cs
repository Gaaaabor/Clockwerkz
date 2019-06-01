using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class FiredTriggerMap
        : IEntityTypeConfiguration<Clockwerkz.Domain.Entities.FiredTrigger>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Clockwerkz.Domain.Entities.FiredTrigger> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("FIRED_TRIGGERS", "Quartz");

            // key
            builder.HasKey(t => new { t.SchedName, t.EntryId });

            // properties
            builder.Property(t => t.SchedName)
                .IsRequired()
                .HasColumnName("SCHED_NAME")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

            builder.Property(t => t.EntryId)
                .IsRequired()
                .HasColumnName("ENTRY_ID")
                .HasColumnType("nvarchar(140)")
                .HasMaxLength(140);

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

            builder.Property(t => t.InstanceName)
                .IsRequired()
                .HasColumnName("INSTANCE_NAME")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.FiredTime)
                .IsRequired()
                .HasColumnName("FIRED_TIME")
                .HasColumnType("bigint");

            builder.Property(t => t.SchedTime)
                .IsRequired()
                .HasColumnName("SCHED_TIME")
                .HasColumnType("bigint");

            builder.Property(t => t.Priority)
                .IsRequired()
                .HasColumnName("PRIORITY")
                .HasColumnType("int");

            builder.Property(t => t.State)
                .IsRequired()
                .HasColumnName("STATE")
                .HasColumnType("nvarchar(16)")
                .HasMaxLength(16);

            builder.Property(t => t.JobName)
                .HasColumnName("JOB_NAME")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.JobGroup)
                .HasColumnName("JOB_GROUP")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.IsNonconcurrent)
                .HasColumnName("IS_NONCONCURRENT")
                .HasColumnType("bit");

            builder.Property(t => t.RequestsRecovery)
                .HasColumnName("REQUESTS_RECOVERY")
                .HasColumnType("bit");

            // relationships
            #endregion
        }

    }
}
