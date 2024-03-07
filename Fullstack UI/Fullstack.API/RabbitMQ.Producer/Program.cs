using RabbitMQ.Client;
using System.Text;
using System.Text.Json.Serialization;

namespace RabbitMQ.Producer
{
    static class Program
    {
        static void Main(string[] args)
        {

            var factory = new ConnectionFactory { 
                Uri = new Uri("amqp://guest:guest@localhost:5672") 
            };
            using (var connection = factory.CreateConnection())
            {
                using var Channel = connection.CreateModel();
                //QueueProducer.publish(Channel);
                //DirectExchangePublisher.Pulish(Channel);
                //TopicExchangePublisher.Pulish(Channel);
                //HeaderExchangePublisher.Pulish(Channel);
                FanoutExchangePublisher.Pulish(Channel);
            }
        }
    }
}