using Clockwerkz.Application.Jobs.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Queries
{
    public class ListJobsQueryHanlder : IRequestHandler<ListJobsQuery, IEnumerable<JobListDto>>
    {
        private readonly IJobManager _jobManager;

        public ListJobsQueryHanlder(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<IEnumerable<JobListDto>> Handle(ListJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _jobManager.GetJobsAsync();
            return jobs;
        }
    }
}
