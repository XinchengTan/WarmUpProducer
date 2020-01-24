using System;
using Newtonsoft.Json.Linq;

namespace Producer
{
    public interface IProducerToConsumerAdpt
    {
        public void Send(JToken record);
    }
}
