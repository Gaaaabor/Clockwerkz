using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence.Mappings
{
    public partial class JobDetailMap : IEntityTypeConfiguration<Domain.Entities.JobDetail>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.JobDetail> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("JOB_DETAILS", "Quartz");

            // key
            builder.HasKey(t => new { t.SchedName, t.JobName, t.JobGroup });

            // properties
            builder.Property(t => t.SchedName)
                .IsRequired()
                .HasColumnName("SCHED_NAME")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

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

            builder.Property(t => t.JobClassName)
                .IsRequired()
                .HasColumnName("JOB_CLASS_NAME")
                .HasColumnType("nvarchar(250)")
                .HasMaxLength(250);

            builder.Property(t => t.IsDurable)
                .IsRequired()
                .HasColumnName("IS_DURABLE")
                .HasColumnType("bit");

            builder.Property(t => t.IsNonconcurrent)
                .IsRequired()
                .HasColumnName("IS_NONCONCURRENT")
                .HasColumnType("bit");

            builder.Property(t => t.IsUpdateData)
                .IsRequired()
                .HasColumnName("IS_UPDATE_DATA")
                .HasColumnType("bit");

            builder.Property(t => t.RequestsRecovery)
                .IsRequired()
                .HasColumnName("REQUESTS_RECOVERY")
                .HasColumnType("bit");

            builder.Property(t => t.JobData)
                .HasColumnName("JOB_DATA")
                .HasColumnType("varbinary(max)");

            // relationships
            #endregion
        }
    }
}
