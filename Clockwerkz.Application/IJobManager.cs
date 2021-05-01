using Clockwerkz.Application.Jobs.Models;
using Clockwerkz.Application.Triggers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clockwerkz.Application
{
    public interface IJobManager
    {
        Task<JobListDto> ScheduleJobAsync(string jobName, string groupName, string description, bool startImmediately, string cronExpression, IDictionary<string, object> jobDataMap);
        Task<bool> PauseJobAsync(string jobName, string groupName);
        Task<bool> DeleteJobAsync(string jobName, string groupName);
        Task<IEnumerable<TriggerDto>> GetTriggersAsync(string jobName, string groupName);
        Task<bool> CreateTriggerAsync(string jobName, string jobGroupName, string triggerName, string triggerGroupName, string triggerDescription, bool startImmediately, string cronExpression, IDictionary<string, object> jobDataMap);
        Task<bool> PauseTriggerAsync(string triggerName, string groupName);
        Task<bool> DeleteTriggerAsync(string triggerName, string groupName);
        Task<IDictionary<string, string>> GetJobDataMapAsync(string jobName, string groupName);

    }
}
