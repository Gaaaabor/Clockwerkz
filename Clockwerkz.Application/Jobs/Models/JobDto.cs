using Clockwerkz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Clockwerkz.Application.Jobs.Models
{
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
}
