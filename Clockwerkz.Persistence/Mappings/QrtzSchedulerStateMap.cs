using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class QrtzSchedulerStateMap
        : IEntityTypeConfiguration<Clockwerkz.Domain.Entities.QrtzSchedulerState>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Clockwerkz.Domain.Entities.QrtzSchedulerState> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("QRTZ_SCHEDULER_STATE", "dbo");

            // key
            builder.HasKey(t => new { t.SchedName, t.InstanceName });

            // properties
            builder.Property(t => t.SchedName)
                .IsRequired()
                .HasColumnName("SCHED_NAME")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

            builder.Property(t => t.InstanceName)
                .IsRequired()
                .HasColumnName("INSTANCE_NAME")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.LastCheckinTime)
                .IsRequired()
                .HasColumnName("LAST_CHECKIN_TIME")
                .HasColumnType("bigint");

            builder.Property(t => t.CheckinInterval)
                .IsRequired()
                .HasColumnName("CHECKIN_INTERVAL")
                .HasColumnType("bigint");

            // relationships
            #endregion
        }

    }
}
