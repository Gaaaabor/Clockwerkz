using Clockwerkz.Application.Jobs.Interfaces;
using Quartz.Simpl;
using System.Collections.Generic;

namespace Clockwerkz.Infrastructure
{
    public class JobDataSerializer : IJobDataSerializer
    {
        private readonly JsonObjectSerializer _jsonObjectSerializer;

        public JobDataSerializer()
        {
            _jsonObjectSerializer = new JsonObjectSerializer();
            _jsonObjectSerializer.Initialize();
        }

        public IDictionary<string, string> Deserialize(byte[] jobData)
        {
            return _jsonObjectSerializer.DeSerialize<IDictionary<string, string>>(jobData);
        }
    }
}
