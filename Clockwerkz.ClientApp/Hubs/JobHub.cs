using Clockwerkz.Application.Jobs.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Clockwerkz.ClientApp.Hubs
{
    public class JobHub : Hub
    {
        public async Task JobScheduled(JobListDto jobListDto)
        {
            await Clients.All.SendAsync("JobScheduled", jobListDto);
        }
    }
}
