using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace RabitMQ.Consumer
{
    static class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using (var connection = factory.CreateConnection())
            {
                using var Channel = connection.CreateModel();

                //var msg = new { name = "producer", Message = "hello !" };
                //var body = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(msg));
                //Channel.BasicPublish("", "Demo-Queue", null, body);
                //var consumer = new EventingBasicConsumer(Channel);
                //consumer.Received += (sender, args) =>
                //{
                //    var body = args.Body.ToArray();
                //    var Message = Encoding.UTF8.GetString(body);
                //    Console.WriteLine(Message);

                //};
                //Channel.BasicConsume("Demo-Queue", true, consumer);

                //QueueConsumer.Consumer(Channel);
                //DirectExchangeConsumer.Consumer(Channel);
                //TopicExchangeConsumer.Consumer(Channel);
                //HeaderExchangeConsumer.Consumer(Channel);
                FanoutExchangeConsumer.Consumer(Channel);
                Console.ReadLine();
            }
        }
    }
}