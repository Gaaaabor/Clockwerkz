using System.Threading.Tasks;

namespace Clockwerkz.Application
{
    public interface IJobManager
    {
        Task Start();
        Task CreateJobAsync();
        Task RemoveJob(string name, string groupName);
    }
}
