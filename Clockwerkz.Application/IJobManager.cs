using Clockwerkz.Application.Jobs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clockwerkz.Application
{
    public interface IJobManager
    {
        Task Start();
        Task ScheduleCustomJobAsync(string name, string groupName, bool startImmediately, string cronExpression, IDictionary<string, object> jobDataMap);
        Task DeleteJobAsync(string name, string groupName);
        Task DeleteTriggerAsync(string name, string groupName);
        Task<JobDetailDto> GetJobDetailAsync(string jobGroup, string jobName);
        Task<IEnumerable<JobListDto>> GetJobsAsync();
        Task<JobListDto> GetJobAsync(string jobGroup, string jobName);
    }
}
