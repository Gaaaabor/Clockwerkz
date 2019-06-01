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
}
