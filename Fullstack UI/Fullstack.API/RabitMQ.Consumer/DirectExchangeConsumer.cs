using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace RabitMQ.Consumer
{
    internal class DirectExchangeConsumer
    {
        public static void Consumer(IModel Channel)
        {
            //Channel.ExchangeDeclare("Demo-Direct-Exchange", ExchangeType.Direct);
            //Channel.QueueDeclare("Demo-Direct-Queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
            //Channel.QueueBind("Demo-Direct-Exchange", "Demo-Direct-Queue", "Account.init");
            //var consumer = new EventingBasicConsumer(Channel);
            //consumer.Received += (sender, args) =>
            //{
            //    var body = args.Body.ToArray();
            //    var Message = Encoding.UTF8.GetString(body);
            //    Console.WriteLine(Message);

            //};
            //Channel.BasicConsume("Demo-Direct-Queue", true, consumer);

            Channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct);
            Channel.QueueDeclare("demo-direct-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            Channel.QueueBind("demo-direct-queue", "demo-direct-exchange", "account.*");
            Channel.BasicQos(0, 100, false);

            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (sender, e) => {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            Channel.BasicConsume("demo-direct-queue", true, consumer);
            Console.WriteLine("Consumer started");
            Console.ReadLine();
        }
    }
}
