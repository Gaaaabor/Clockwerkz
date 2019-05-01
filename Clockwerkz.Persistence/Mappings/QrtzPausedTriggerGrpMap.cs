using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class QrtzPausedTriggerGrpMap
        : IEntityTypeConfiguration<Clockwerkz.Domain.Entities.QrtzPausedTriggerGrp>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Clockwerkz.Domain.Entities.QrtzPausedTriggerGrp> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("QRTZ_PAUSED_TRIGGER_GRPS", "dbo");

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
