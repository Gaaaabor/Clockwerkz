using Clockwerkz.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Clockwerkz.Application.Jobs.Models
{
    public class JobListDto
    {
        public string JobName { get; set; }
        public string JobGroup { get; set; }
        public string TriggerGroup { get; set; }
        public string TriggerName { get; set; }        
        public string State { get; set; }
        public string Type { get; set; }
        public long StartTime { get; set; }
        public long? EndTime { get; set; }
        public long? PreviousFireTime { get; set; }
        public long? NextFireTime { get; set; }

        public static Expression<Func<JobDetail, Trigger, JobListDto>> Projection
        {
            get
            {
                return (jobDetail, trigger) => new JobListDto
                {
                    JobGroup = jobDetail.JobGroup,
                    JobName = jobDetail.JobName,

                    TriggerGroup = trigger.TriggerGroup,
                    TriggerName = trigger.TriggerName,                    
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
