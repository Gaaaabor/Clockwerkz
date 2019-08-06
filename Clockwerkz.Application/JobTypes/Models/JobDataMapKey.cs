using System.Collections.Generic;

namespace Clockwerkz.Application.JobTypes.Models
{
    public class JobDataMapKey
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<DropdownValue> DropdownValues { get; set; }
    }

    public class DropdownValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
