using MediatR;
using System.Collections.Generic;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class JobScheduleCommand : IRequest
    {
        public string JobName { get; set; }
        public string GroupName { get; set; }
        public bool StartImmediately { get; set; }
        public string CronExpression { get; set; }
        public Dictionary<string, object> JobDataMap { get; set; }
    }
}
