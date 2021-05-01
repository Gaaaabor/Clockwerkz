using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Queries
{
    public class JobDetailsQueryHandler : IRequestHandler<JobDetailsQuery, IDictionary<string, string>>
    {
        private readonly IJobManager _jobManager;

        public JobDetailsQueryHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<IDictionary<string, string>> Handle(JobDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _jobManager.GetJobDataMapAsync(request.JobName, request.GroupName);
            return result;
        }
    }
}
