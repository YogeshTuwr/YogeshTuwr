using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabitMQ.Consumer
{
    public static class QueueConsumer
    {
        public static void Consumer( IModel Channel)
        {
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                var Message = Encoding.UTF8.GetString(body);
                Console.WriteLine(Message);

            };
            Channel.BasicConsume("demo-queue", true, consumer);
        }
    }
}
