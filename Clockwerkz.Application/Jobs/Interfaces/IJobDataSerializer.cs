using System.Collections.Generic;

namespace Clockwerkz.Application.Jobs.Interfaces
{
    public interface IJobDataSerializer
    {
        IDictionary<string, string> Deserialize(byte[] jobData);
    }
}
