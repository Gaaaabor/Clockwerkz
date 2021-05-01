using Clockwerkz.Application.Interfaces;
using Clockwerkz.Application.Jobs.Models;
using Clockwerkz.Application.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class ScheduleJobCommandHandler : IRequestHandler<ScheduleJobCommand, JobListDto>
    {
        private readonly IJobManager _jobManager;
        private readonly INotificationService _notificationService;

        public ScheduleJobCommandHandler(IJobManager jobManager, INotificationService notificationService)
        {
            _jobManager = jobManager;
            _notificationService = notificationService;
        }

        public async Task<JobListDto> Handle(ScheduleJobCommand request, CancellationToken cancellationToken)
        {
            var result = await _jobManager.ScheduleJobAsync(
                request.JobName,
                request.GroupName,
                request.Description,
                request.StartImmediately,
                request.CronExpression,
                request.JobDataMap);

            await _notificationService.SendAsync(new JobScheduledNotificationMessage(result));

            return result;
        }
    }
}
