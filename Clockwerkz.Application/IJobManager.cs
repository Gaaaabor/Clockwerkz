using Clockwerkz.Application.Jobs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clockwerkz.Application
{
    public interface IJobManager
    {
        Task Start();
        Task ScheduleCustomJob(string name, string groupName, bool startImmediately, string cronExpression, IDictionary<string, object> jobDataMap);
        Task DeleteJob(string name, string groupName);
        Task DeleteTrigger(string name, string groupName);
        Task<JobDetailDto> GetJobDetail(string jobGroup, string jobName);
    }
}
