using MediatR;
using System.Collections.Generic;

namespace Clockwerkz.Application.Triggers.Commands
{
    public class CreateTriggerCommand : IRequest<bool>
    {
        public string JobName { get; set; }
        public string JobGroupName { get; set; }
        public string TriggerName { get; set; }
        public string TriggerGroupName { get; set; }
        public string TriggerDescription { get; set; }
        public bool StartImmediately { get; set; }
        public string CronExpression { get; set; }
        public IDictionary<string, object> JobDataMap { get; set; }
    }
}
