﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clockwerkz.Domain.Entities
{
    [Table("CRON_TRIGGERS", Schema = "Quartz")]
    public partial class CronTrigger
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

        [Required]
        [Column("CRON_EXPRESSION")]
        [StringLength(120)]
        public string CronExpression { get; set; }

        [Column("TIME_ZONE_ID")]
        [StringLength(80)]
        public string TimeZoneId { get; set; }

        [ForeignKey("SchedName,TriggerName,TriggerGroup")]
        [InverseProperty("CronTrigger")]
        public virtual Trigger Trigger { get; set; }
    }
}