using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace RabbitMQ.Producer
{
    internal class DirectExchangePublisher
    {
        public static void Pulish(IModel Channel)
        {
            var ttl = new Dictionary<string, object>
            {
                {"x-message-ttl", 30000 }
            };

            Channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct, arguments: ttl);
            var cnt = 0;
            while (true)
            {
                var msg = new { name = "producer", Message = $"Hello Count : {cnt} !" };
        var body = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(msg));
        Channel.BasicPublish("demo-direct-exchange", "account.init", null, body);
                cnt++;
                Thread.Sleep(100);
            }
}
        //public static void DirectExchangePublisher(IModel Channel) {
        //    Channel.ExchangeDeclare("Demo-Direct-Exchange", ExchangeType.Direct);
        //    var cnt = 0;
        //    while (true)
        //    {
        //        var msg = new { name = "producer", Message = $"Hello Count : {cnt} !" };
        //        var body = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(msg));
        //        Channel.BasicPublish("Demo-Direct-Exchange", "Acount.init", null, body);
        //        cnt++;
        //        Thread.Sleep(100);
        //    }

        //}
    }
}
