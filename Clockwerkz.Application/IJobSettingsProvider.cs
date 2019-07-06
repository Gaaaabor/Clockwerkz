using Clockwerkz.Application.JobTypes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clockwerkz.Application
{
    public interface IJobSettingsProvider
    {
        Task<ICollection<JobType>> ListJobTypesAsync();
        Task<ICollection<string>> ListDefaultJobDataMapKeys();
    }
}
