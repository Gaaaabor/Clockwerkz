using Clockwerkz.Application.Jobs.Models;
using MediatR;
using System.Collections.Generic;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class ScheduleJobCommand : IRequest<JobListDto>
    {
        public string JobName { get; set; }
        public string GroupName { get; set; }
        public bool StartImmediately { get; set; }
        public string CronExpression { get; set; }
        public Dictionary<string, object> JobDataMap { get; set; }
    }
}
