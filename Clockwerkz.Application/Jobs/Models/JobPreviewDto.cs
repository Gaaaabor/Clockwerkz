using Clockwerkz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Clockwerkz.Application.Jobs.Models
{
    public class JobPreviewDto
    {
        public string GroupName { get; set; }
        public IEnumerable<JobDto> Jobs { get; set; }

        public static Expression<Func<IGrouping<string, JobDetail>, JobPreviewDto>> Projection
        {
            get
            {
                return grouping => new JobPreviewDto
                {
                    GroupName = grouping.Key,
                    Jobs = grouping
                    .AsQueryable()
                    .Select(JobDto.Projection)
                };
            }
        }
    }

    public class JobDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TriggerDto> Triggers { get; set; }

        public static Expression<Func<JobDetail, JobDto>> Projection
        {
            get
            {
                return jobDetail => new JobDto
                {
                    Id = $"{jobDetail.JobGroup}_{jobDetail.JobName}",
                    Name = jobDetail.JobName,
                    Triggers = jobDetail.Triggers
                    .AsQueryable()
                    .Select(TriggerDto.Projection)
                };
            }
        }
    }

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
