using Clockwerkz.Application.Interfaces;
using Clockwerkz.Application.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class ScheduleJobCommandHandler : IRequestHandler<ScheduleJobCommand>
    {
        private readonly IJobManager _jobManager;
        private readonly INotificationService _notificationService;

        public ScheduleJobCommandHandler(IJobManager jobManager, INotificationService notificationService)
        {
            _jobManager = jobManager;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(ScheduleJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobManager.ScheduleCustomJobAsync(
                request.JobName,
                request.GroupName,
                request.StartImmediately,
                request.CronExpression,
                request.JobDataMap);

            await _notificationService.SendAsync(new JobScheduledNotificationMessage(job));

            return Unit.Value;
        }
    }
}
