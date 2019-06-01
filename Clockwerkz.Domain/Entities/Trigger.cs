using System;
using System.Collections.Generic;

namespace Clockwerkz.Domain.Entities
{
    public partial class Trigger
    {
        public Trigger()
        {
            #region Generated Constructor
            CronTriggers = new HashSet<CronTrigger>();
            SimpleTriggers = new HashSet<SimpleTrigger>();
            SimpropTriggers = new HashSet<SimpropTrigger>();
            #endregion
        }

        #region Generated Properties
        public string SchedName { get; set; }

        public string TriggerName { get; set; }

        public string TriggerGroup { get; set; }

        public string JobName { get; set; }

        public string JobGroup { get; set; }

        public string Description { get; set; }

        public long? NextFireTime { get; set; }

        public long? PrevFireTime { get; set; }

        public int? Priority { get; set; }

        public string TriggerState { get; set; }

        public string TriggerType { get; set; }

        public long StartTime { get; set; }

        public long? EndTime { get; set; }

        public string CalendarName { get; set; }

        public int? MisfireInstr { get; set; }

        public Byte[] JobData { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<CronTrigger> CronTriggers { get; set; }

        public virtual JobDetail JobDetail { get; set; }

        public virtual ICollection<SimpleTrigger> SimpleTriggers { get; set; }

        public virtual ICollection<SimpropTrigger> SimpropTriggers { get; set; }

        #endregion

    }
}
