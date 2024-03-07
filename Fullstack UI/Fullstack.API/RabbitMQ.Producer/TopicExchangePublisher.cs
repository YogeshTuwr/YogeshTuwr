using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Producer
{
    internal class TopicExchangePublisher
    {
        public static void Pulish(IModel Channel)
        {
            var ttl = new Dictionary<string, object>
            {
                {"x-message-ttl", 30000 }
            };

            Channel.ExchangeDeclare("demo-topic-exchange", ExchangeType.Topic, arguments: ttl);
            var cnt = 0;
            while (true)
            {
                var msg = new { name = "producer", Message = $"Hello Count : {cnt} !" };
                var body = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(msg));
                Channel.BasicPublish("demo-topic-exchange", "account.Insert", null, body);
                cnt++;
                Thread.Sleep(100);
            }
        }
    }
}
