using Clockwerkz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Domain
{
    public interface IClockwerkzDbContext
    {
        DbSet<BlobTrigger> BlobTriggers { get; set; }
        DbSet<Calendar> Calendars { get; set; }
        DbSet<CronTrigger> CronTriggers { get; set; }
        DbSet<FiredTrigger> FiredTriggers { get; set; }
        DbSet<JobDetail> JobDetails { get; set; }
        DbSet<Lock> Locks { get; set; }
        DbSet<PausedTriggerGrp> PausedTriggerGrps { get; set; }
        DbSet<SchedulerState> SchedulerStates { get; set; }
        DbSet<SimpleTrigger> SimpleTriggers { get; set; }
        DbSet<SimpropTrigger> SimpropTriggers { get; set; }
        DbSet<Trigger> Triggers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}