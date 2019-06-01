using Clockwerkz.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Clockwerkz.Application.Jobs.Models
{
    public class TriggerDto
    {
        public string Id { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public long StartTime { get; set; }
        public long? EndTime { get; set; }
        public long? PreviousFireTime { get; set; }
        public long? NextFireTime { get; set; }

        public static Expression<Func<Trigger, TriggerDto>> Projection
        {
            get
            {
                return trigger => new TriggerDto
                {
                    Id = $"{trigger.JobGroup}_{trigger.TriggerName}",
                    State = trigger.TriggerState,
                    Type = trigger.TriggerType,
                    StartTime = trigger.StartTime,
                    EndTime = trigger.EndTime,
                    PreviousFireTime = trigger.PrevFireTime,
                    NextFireTime = trigger.NextFireTime
                };
            }
        }
    }
}
