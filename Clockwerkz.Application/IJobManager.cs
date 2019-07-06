using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clockwerkz.Application
{
    public interface IJobManager
    {
        Task Start();
        Task ScheduleCustomJob(string name, string groupName, bool startImmediately, string cronExpression, IDictionary<string, object> jobDataMap);
        Task RemoveJob(string name, string groupName);
    }
}
