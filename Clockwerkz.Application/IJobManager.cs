using System.Threading.Tasks;

namespace Clockwerkz.Application
{
    public interface IJobManager
    {
        Task Start();
        Task CreateJobAsync(int count = 10);
        Task ScheduleDeviceActivationJob(string name, string groupName, bool startImmediately, string cronExpression, string deviceSerial);
        Task RemoveJob(string name, string groupName);        
    }
}
