using System;
using System.Collections.Generic;

namespace Clockwerkz.Domain.Entities
{
    public partial class BlobTrigger
    {
        public BlobTrigger()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public string SchedName { get; set; }

        public string TriggerName { get; set; }

        public string TriggerGroup { get; set; }

        public Byte[] BlobData { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
