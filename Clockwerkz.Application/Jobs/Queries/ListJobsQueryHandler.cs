using Clockwerkz.Application.Jobs.Models;
using Clockwerkz.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Queries
{
    public class ListJobsQueryHanlder : IRequestHandler<ListJobsQuery, IEnumerable<JobListDto>>
    {
        private readonly IClockwerkzDbContext _context;

        public ListJobsQueryHanlder(IClockwerkzDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobListDto>> Handle(ListJobsQuery request, CancellationToken cancellationToken)
        {
            var jobDetailsQuery = _context.JobDetails
                .OrderBy(x => x.SchedName)
                .ThenBy(x => x.JobName)
                .ThenBy(x => x.JobGroup)
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.SchedulerName))
            {
                jobDetailsQuery = jobDetailsQuery.Where(x => x.SchedName == request.SchedulerName);
            }

            if (!string.IsNullOrEmpty(request.JobName))
            {
                jobDetailsQuery = jobDetailsQuery.Where(x => x.JobName.Contains(request.JobName));
            }

            if (!string.IsNullOrEmpty(request.GroupName))
            {
                jobDetailsQuery = jobDetailsQuery.Where(x => x.JobGroup.Contains(request.GroupName));
            }

            var jobs = await jobDetailsQuery
                .Select(JobListDto.Projection)
                .ToListAsync(cancellationToken);

            return jobs;
        }
    }
}
