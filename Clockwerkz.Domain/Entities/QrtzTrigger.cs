using System;
using System.Collections.Generic;

namespace Clockwerkz.Domain.Entities
{
    public partial class QrtzTrigger
    {
        public QrtzTrigger()
        {
            #region Generated Constructor
            QrtzCronTriggers = new HashSet<QrtzCronTrigger>();
            QrtzSimpleTriggers = new HashSet<QrtzSimpleTrigger>();
            QrtzSimpropTriggers = new HashSet<QrtzSimpropTrigger>();
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
        public virtual ICollection<QrtzCronTrigger> QrtzCronTriggers { get; set; }

        public virtual QrtzJobDetail QrtzJobDetail { get; set; }

        public virtual ICollection<QrtzSimpleTrigger> QrtzSimpleTriggers { get; set; }

        public virtual ICollection<QrtzSimpropTrigger> QrtzSimpropTriggers { get; set; }

        #endregion

    }
}
