using Clockwerkz.Application.Jobs.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class ScheduleJobCommandHandler : IRequestHandler<ScheduleJobCommand, JobListDto>
    {
        private readonly IJobManager _jobManager;

        public ScheduleJobCommandHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<JobListDto> Handle(ScheduleJobCommand request, CancellationToken cancellationToken)
        {
            await _jobManager.ScheduleCustomJobAsync(
                request.JobName,
                request.GroupName,
                request.StartImmediately,
                request.CronExpression,
                request.JobDataMap);

            var job = await _jobManager.GetJobAsync(request.GroupName, request.JobName);
            return job;
        }
    }
}
