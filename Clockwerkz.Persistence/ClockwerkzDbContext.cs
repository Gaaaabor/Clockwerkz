using Clockwerkz.Domain;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Persistence
{
    public partial class ClockwerkzDbContext : DbContext, IClockwerkzDbContext
    {
        public ClockwerkzDbContext(DbContextOptions<ClockwerkzDbContext> options)
            : base(options)
        {
        }

        #region Generated Properties
        public virtual DbSet<Clockwerkz.Domain.Entities.QrtzBlobTrigger> QrtzBlobTriggers { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.QrtzCalendar> QrtzCalendars { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.QrtzCronTrigger> QrtzCronTriggers { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.QrtzFiredTrigger> QrtzFiredTriggers { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.QrtzJobDetail> QrtzJobDetails { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.QrtzLock> QrtzLocks { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.QrtzPausedTriggerGrp> QrtzPausedTriggerGrps { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.QrtzSchedulerState> QrtzSchedulerStates { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.QrtzSimpleTrigger> QrtzSimpleTriggers { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.QrtzSimpropTrigger> QrtzSimpropTriggers { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.QrtzTrigger> QrtzTriggers { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.QrtzBlobTriggerMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.QrtzCalendarMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.QrtzCronTriggerMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.QrtzFiredTriggerMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.QrtzJobDetailMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.QrtzLockMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.QrtzPausedTriggerGrpMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.QrtzSchedulerStateMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.QrtzSimpleTriggerMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.QrtzSimpropTriggerMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.QrtzTriggerMap());
            #endregion
        }
    }
}
