using System;
using System.Collections.Generic;

namespace Clockwerkz.Domain.Entities
{
    public partial class QrtzJobDetail
    {
        public QrtzJobDetail()
        {
            #region Generated Constructor
            QrtzTriggers = new HashSet<QrtzTrigger>();
            #endregion
        }

        #region Generated Properties
        public string SchedName { get; set; }

        public string JobName { get; set; }

        public string JobGroup { get; set; }

        public string Description { get; set; }

        public string JobClassName { get; set; }

        public bool IsDurable { get; set; }

        public bool IsNonconcurrent { get; set; }

        public bool IsUpdateData { get; set; }

        public bool RequestsRecovery { get; set; }

        public Byte[] JobData { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<QrtzTrigger> QrtzTriggers { get; set; }

        #endregion

    }
}
