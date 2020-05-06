using Clockwerkz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Clockwerkz.Application.Jobs.Models
{
    public class JobDetailDto
    {
        public string JobName { get; set; }
        public string JobGroup { get; set; }
        public IEnumerable<TriggerDto> Triggers { get; set; }
        public IDictionary<string, string> JobDataMap { get; set; }

        internal static Expression<Func<JobDetail, JobDetailDto>> Projection
        {
            get
            {
                return jobDetail => new JobDetailDto
                {
                    JobName = jobDetail.JobName,
                    JobGroup = jobDetail.JobGroup,                    
                    Triggers = jobDetail.Triggers.AsQueryable().Select(TriggerDto.Projection)
                };
            }
        }

        internal static JobDetailDto Create(JobDetail jobDetail)
        {
            return Projection.Compile()(jobDetail);
        }
    }
}
