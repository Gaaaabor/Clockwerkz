using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class QrtzLockMap
        : IEntityTypeConfiguration<Clockwerkz.Domain.Entities.QrtzLock>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Clockwerkz.Domain.Entities.QrtzLock> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("QRTZ_LOCKS", "dbo");

            // key
            builder.HasKey(t => new { t.SchedName, t.LockName });

            // properties
            builder.Property(t => t.SchedName)
                .IsRequired()
                .HasColumnName("SCHED_NAME")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

            builder.Property(t => t.LockName)
                .IsRequired()
                .HasColumnName("LOCK_NAME")
                .HasColumnType("nvarchar(40)")
                .HasMaxLength(40);

            // relationships
            #endregion
        }

    }
}
