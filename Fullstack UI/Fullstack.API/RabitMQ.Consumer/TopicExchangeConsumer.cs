using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabitMQ.Consumer
{
    public static class TopicExchangeConsumer
    {
        public static void Consumer(IModel Channel)
        {
            Channel.ExchangeDeclare("demo-topic-exchange", ExchangeType.Topic);
            Channel.QueueDeclare("demo-topic-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            Channel.QueueBind("demo-topic-queue", "demo-topic-exchange", "account.*");
            Channel.BasicQos(0, 100, false);

            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (sender, e) => {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            Channel.BasicConsume("demo-topic-queue", true, consumer);
            Console.WriteLine("Consumer started");
            Console.ReadLine();
        }
    }
}
