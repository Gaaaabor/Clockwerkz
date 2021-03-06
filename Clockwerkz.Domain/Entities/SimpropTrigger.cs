﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clockwerkz.Domain.Entities
{
    [Table("SIMPROP_TRIGGERS", Schema = "Quartz")]
    public partial class SimpropTrigger
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

        [Column("STR_PROP_1")]
        [StringLength(512)]
        public string StrProp1 { get; set; }

        [Column("STR_PROP_2")]
        [StringLength(512)]
        public string StrProp2 { get; set; }

        [Column("STR_PROP_3")]
        [StringLength(512)]
        public string StrProp3 { get; set; }

        [Column("INT_PROP_1")]
        public int? IntProp1 { get; set; }

        [Column("INT_PROP_2")]
        public int? IntProp2 { get; set; }

        [Column("LONG_PROP_1")]
        public long? LongProp1 { get; set; }

        [Column("LONG_PROP_2")]
        public long? LongProp2 { get; set; }

        [Column("DEC_PROP_1", TypeName = "numeric(13, 4)")]
        public decimal? DecProp1 { get; set; }

        [Column("DEC_PROP_2", TypeName = "numeric(13, 4)")]
        public decimal? DecProp2 { get; set; }

        [Column("BOOL_PROP_1")]
        public bool? BoolProp1 { get; set; }

        [Column("BOOL_PROP_2")]
        public bool? BoolProp2 { get; set; }

        [Column("TIME_ZONE_ID")]
        [StringLength(80)]
        public string TimeZoneId { get; set; }

        [ForeignKey("SchedName,TriggerName,TriggerGroup")]
        [InverseProperty("SimpropTrigger")]
        public virtual Trigger Trigger { get; set; }
    }
}