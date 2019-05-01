using System;
using System.Collections.Generic;

namespace Clockwerkz.Domain.Entities
{
    public partial class QrtzSimpleTrigger
    {
        public QrtzSimpleTrigger()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public string SchedName { get; set; }

        public string TriggerName { get; set; }

        public string TriggerGroup { get; set; }

        public int RepeatCount { get; set; }

        public long RepeatInterval { get; set; }

        public int TimesTriggered { get; set; }

        #endregion

        #region Generated Relationships
        public virtual QrtzTrigger QrtzTrigger { get; set; }

        #endregion

    }
}
