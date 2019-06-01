using Microsoft.EntityFrameworkCore;
using Clockwerkz.Domain;

namespace Clockwerkz.Persistence
{
    public partial class ClockwerkzDbContext : DbContext, IClockwerkzDbContext
    {
        public ClockwerkzDbContext(DbContextOptions<ClockwerkzDbContext> options)
            : base(options)
        {
        }

        #region Generated Properties
        public virtual DbSet<Clockwerkz.Domain.Entities.BlobTrigger> BlobTriggers { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.Calendar> Calendars { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.CronTrigger> CronTriggers { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.FiredTrigger> FiredTriggers { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.JobDetail> JobDetails { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.Lock> Locks { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.PausedTriggerGrp> PausedTriggerGrps { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.SchedulerState> SchedulerStates { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.SimpleTrigger> SimpleTriggers { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.SimpropTrigger> SimpropTriggers { get; set; }

        public virtual DbSet<Clockwerkz.Domain.Entities.Trigger> Triggers { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.BlobTriggerMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.CalendarMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.CronTriggerMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.FiredTriggerMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.JobDetailMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.LockMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.PausedTriggerGrpMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.SchedulerStateMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.SimpleTriggerMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.SimpropTriggerMap());
            modelBuilder.ApplyConfiguration(new Clockwerkz.Persistence.Mappings.TriggerMap());
            #endregion
        }
    }
}
