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
    public class ListJobsQueryHanlder : IRequestHandler<ListJobsQuery, ICollection<JobListDto>>
    {
        private readonly IClockwerkzDbContext _context;

        public ListJobsQueryHanlder(IClockwerkzDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<JobListDto>> Handle(ListJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _context.JobDetails
                .OrderBy(x => x.JobGroup)
                .ThenBy(x => x.JobName)
                .GroupJoin(
                    _context.Triggers,
                    jobDetail => new { jobDetail.JobName, jobDetail.JobGroup },
                    trigger => new { trigger.JobName, trigger.JobGroup },
                    JobListDto.Projection)
                .ToListAsync(cancellationToken);

            return jobs;
        }
    }
}
