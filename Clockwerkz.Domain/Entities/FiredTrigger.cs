using System;
using System.Collections.Generic;

namespace Clockwerkz.Domain.Entities
{
    public partial class FiredTrigger
    {
        public FiredTrigger()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public string SchedName { get; set; }

        public string EntryId { get; set; }

        public string TriggerName { get; set; }

        public string TriggerGroup { get; set; }

        public string InstanceName { get; set; }

        public long FiredTime { get; set; }

        public long SchedTime { get; set; }

        public int Priority { get; set; }

        public string State { get; set; }

        public string JobName { get; set; }

        public string JobGroup { get; set; }

        public bool? IsNonconcurrent { get; set; }

        public bool? RequestsRecovery { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}