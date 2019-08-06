using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class ScheduleJobCommandHandler : IRequestHandler<ScheduleJobCommand>
    {
        private readonly IJobManager _jobManager;

        public ScheduleJobCommandHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<Unit> Handle(ScheduleJobCommand request, CancellationToken cancellationToken)
        {
            await _jobManager.ScheduleCustomJob(
                request.JobName,
                request.GroupName,
                request.StartImmediately,
                request.CronExpression,
                request.JobDataMap);

            return Unit.Value;
        }
    }
}
