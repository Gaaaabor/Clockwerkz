using Clockwerkz.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Clockwerkz.Application.Jobs.Models
{
    public class JobListDto
    {
        public string SchedulerName { get; set; }
        public string JobName { get; set; }
        public string JobGroup { get; set; }
        public string Description { get; set; }

        internal static Expression<Func<JobDetail, JobListDto>> Projection
        {
            get
            {
                return jobDetail => new JobListDto
                {
                    SchedulerName = jobDetail.SchedName,
                    JobName = jobDetail.JobName,
                    JobGroup = jobDetail.JobGroup,
                    Description = jobDetail.Description
                };
            }
        }
    }
}
