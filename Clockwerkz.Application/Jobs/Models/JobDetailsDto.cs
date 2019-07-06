using Clockwerkz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Clockwerkz.Application.Jobs.Models
{
    public class JobDetailsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string JobGroup { get; set; }
        public IEnumerable<TriggerDto> Triggers { get; set; }

        public static Expression<Func<JobDetail, JobDetailsDto>> Projection
        {
            get
            {
                return jobDetail => new JobDetailsDto
                {
                    Id = $"{jobDetail.JobGroup}_{jobDetail.JobName}",
                    JobGroup = jobDetail.JobGroup,
                    Name = jobDetail.JobName,
                    Triggers = jobDetail.Triggers
                    .AsQueryable()
                    .Select(TriggerDto.Projection)
                };
            }
        }
    }
}
