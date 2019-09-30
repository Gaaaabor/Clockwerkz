using System.Collections.Generic;

namespace Clockwerkz.Application.Jobs.Models
{
    public class JobDetailDto
    {
        public string JobName { get; set; }
        public string JobGroup { get; set; }
        public IEnumerable<TriggerDto> Triggers { get; set; }
        public IDictionary<string, string> JobDataMap { get; set; }
    }
}
