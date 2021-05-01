using System;

namespace Clockwerkz.Application.Triggers.Models
{
    public class TriggerDto
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public DateTimeOffset? PreviousFireTime { get; set; }
        public DateTimeOffset? NextFireTime { get; set; }
    }
}
