using Clockwerkz.Application;
using Clockwerkz.Application.JobTypes.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ICollection<JobType>> ListJobTypesAsync()
        {
            await Task.CompletedTask;
            return _jobSettings.JobTypes;
        }

        public async Task<ICollection<JobDataMapKey>> ListJobDataMapKeys(string group)
        {
            await Task.CompletedTask;

            var jobDataMapKeys = new List<JobDataMapKey>();

            foreach (var jobDataMapKey in _jobSettings.JobDataMapKeys)
            {
                var groups = jobDataMapKey.Groups.Split(';');
                if (groups.Contains(group, StringComparer.OrdinalIgnoreCase))
                {
                    jobDataMapKeys.Add(jobDataMapKey);
                }
            }

            return jobDataMapKeys;
        }
    }
}