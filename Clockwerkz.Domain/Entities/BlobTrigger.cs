﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clockwerkz.Domain.Entities
{
    [Table("BLOB_TRIGGERS", Schema = "Quartz")]
    public partial class BlobTrigger
    {
        [Key]
        [Column("SCHED_NAME")]
        [StringLength(120)]
        public string SchedName { get; set; }

        [Key]
        [Column("TRIGGER_NAME")]
        [StringLength(150)]
        public string TriggerName { get; set; }

        [Key]
        [Column("TRIGGER_GROUP")]
        [StringLength(150)]
        public string TriggerGroup { get; set; }

        [Column("BLOB_DATA")]
        public byte[] BlobData { get; set; }
    }
}