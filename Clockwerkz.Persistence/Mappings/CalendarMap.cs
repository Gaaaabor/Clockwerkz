using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class CalendarMap
        : IEntityTypeConfiguration<Clockwerkz.Domain.Entities.Calendar>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Clockwerkz.Domain.Entities.Calendar> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("CALENDARS", "Quartz");

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

            builder.Property(t => t.CalendarMember)
                .IsRequired()
                .HasColumnName("CALENDAR")
                .HasColumnType("varbinary(max)");

            // relationships
            #endregion
        }

    }
}
