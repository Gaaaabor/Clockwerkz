using Clockwerkz.Application.Jobs.Models;
using System.Collections.Generic;

namespace Clockwerkz.Infrastructure.Comparers
{
    public class JobListDtoComparer : IComparer<JobListDto>
    {
        public int Compare(JobListDto x, JobListDto y)
        {
            return 
                string.Compare(x.JobGroup, y.JobGroup, true) + 
                string.Compare(x.JobName, y.JobName, true);
        }
    }
}
