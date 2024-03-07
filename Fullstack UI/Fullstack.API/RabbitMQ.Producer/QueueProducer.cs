using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace RabbitMQ.Producer
{
    internal class QueueProducer
    {
        public static void publish(IModel Channel)
        {

            Channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
            var cnt = 0;
            while (true)
            {
                var msg = new { name = "producer", Message = $"Hello Count : {cnt} !" };
                var body = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(msg));
                Channel.BasicPublish("", "demo-queue", null, body);
                cnt++;
                Thread.Sleep(100);
            }
            

        }
    }
}
