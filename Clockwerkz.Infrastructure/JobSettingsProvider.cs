using Clockwerkz.Application;
using Clockwerkz.Application.JobTypes.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clockwerkz.Infrastructure
{
    public class JobSettingsProvider : IJobSettingsProvider
    {
        public const string JobSettingKey = "JobSettings";

        private readonly JobSettings _jobSettings;

        public JobSettingsProvider(IConfiguration configuration)
        {
            var jobSettings = new JobSettings();
            configuration.Bind(JobSettingKey, jobSettings);
            _jobSettings = jobSettings;
        }

        public async Task<ICollection<JobType>> GetJobTypesAsync()
        {
            await Task.CompletedTask;
            return _jobSettings.JobTypes;
        }
    }
}