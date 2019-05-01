using System;
using System.Collections.Generic;

namespace Clockwerkz.Domain.Entities
{
    public partial class QrtzCronTrigger
    {
        public QrtzCronTrigger()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public string SchedName { get; set; }

        public string TriggerName { get; set; }

        public string TriggerGroup { get; set; }

        public string CronExpression { get; set; }

        public string TimeZoneId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual QrtzTrigger QrtzTrigger { get; set; }

        #endregion

    }
}
