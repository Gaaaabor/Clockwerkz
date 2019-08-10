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
    public class ListJobsQueryHanlder : IRequestHandler<ListJobsQuery, ICollection<JobDetailsDto>>
    {
        private readonly IClockwerkzDbContext _context;

        public ListJobsQueryHanlder(IClockwerkzDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<JobDetailsDto>> Handle(ListJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _context.JobDetails                
                .Include(x => x.Triggers)
                .OrderBy(x => x.JobGroup)
                .ThenBy(x => x.JobName)
                .Select(JobDetailsDto.Projection)
                .ToListAsync();

            return jobs;
        }
    }
}
