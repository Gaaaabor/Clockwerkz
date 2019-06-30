using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class JobScheduleCommandHandler : IRequestHandler<JobScheduleCommand>
    {
        private readonly IJobManager _jobManager;

        public JobScheduleCommandHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<Unit> Handle(JobScheduleCommand request, CancellationToken cancellationToken)
        {
            await _jobManager.ScheduleDeviceActivationJob(
                request.JobName,
                request.GroupName,
                request.StartImmediately,
                request.CronExpression,
                request.DeviceSerial);

            return Unit.Value;
        }
    }
}
