using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class QrtzCalendarMap
        : IEntityTypeConfiguration<Clockwerkz.Domain.Entities.QrtzCalendar>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Clockwerkz.Domain.Entities.QrtzCalendar> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("QRTZ_CALENDARS", "dbo");

            // key
            builder.HasKey(t => new { t.SchedName, t.CalendarName });

            // properties
            builder.Property(t => t.SchedName)
                .IsRequired()
                .HasColumnName("SCHED_NAME")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

            builder.Property(t => t.CalendarName)
                .IsRequired()
                .HasColumnName("CALENDAR_NAME")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.Calendar)
                .IsRequired()
                .HasColumnName("CALENDAR")
                .HasColumnType("varbinary(max)");

            // relationships
            #endregion
        }

    }
}
