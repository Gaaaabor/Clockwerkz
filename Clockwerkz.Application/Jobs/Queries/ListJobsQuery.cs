using Clockwerkz.Application.Jobs.Models;
using MediatR;
using System.Collections.Generic;

namespace Clockwerkz.Application.Jobs.Queries
{
    public class ListJobsQuery : IRequest<IEnumerable<JobListDto>>
    {
        public string SchedulerName { get; set; }
        public string JobName { get; set; }
        public string GroupName { get; set; }
    }
}
