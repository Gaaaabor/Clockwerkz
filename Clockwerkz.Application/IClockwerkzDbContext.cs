using Clockwerkz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Application
{
    public interface IClockwerkzDbContext
    {
        DbSet<QrtzBlobTrigger> QrtzBlobTriggers { get; set; }
        DbSet<QrtzCalendar> QrtzCalendars { get; set; }
        DbSet<QrtzCronTrigger> QrtzCronTriggers { get; set; }
        DbSet<QrtzFiredTrigger> QrtzFiredTriggers { get; set; }
        DbSet<QrtzJobDetail> QrtzJobDetails { get; set; }
        DbSet<QrtzLock> QrtzLocks { get; set; }
        DbSet<QrtzPausedTriggerGrp> QrtzPausedTriggerGrps { get; set; }
        DbSet<QrtzSchedulerState> QrtzSchedulerStates { get; set; }
        DbSet<QrtzSimpleTrigger> QrtzSimpleTriggers { get; set; }
        DbSet<QrtzSimpropTrigger> QrtzSimpropTriggers { get; set; }
        DbSet<QrtzTrigger> QrtzTriggers { get; set; }
    }
}