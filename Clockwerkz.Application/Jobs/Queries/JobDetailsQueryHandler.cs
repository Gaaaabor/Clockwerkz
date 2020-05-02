using Clockwerkz.Application.Jobs.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Queries
{
    public class JobDetailsQueryHandler : IRequestHandler<JobDetailsQuery, JobDetailDto>
    {
        private readonly IJobManager _jobManager;

        public JobDetailsQueryHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<JobDetailDto> Handle(JobDetailsQuery request, CancellationToken cancellationToken)
        {
            var jobDetail = await _jobManager.GetJobDetailAsync(request.JobGroup, request.JobName);
            if (jobDetail == null)
            {
                return null;
            }

            return jobDetail;
        }
    }
}
