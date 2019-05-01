using System;
using System.Collections.Generic;

namespace Clockwerkz.Domain.Entities
{
    public partial class QrtzSchedulerState
    {
        public QrtzSchedulerState()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public string SchedName { get; set; }

        public string InstanceName { get; set; }

        public long LastCheckinTime { get; set; }

        public long CheckinInterval { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
