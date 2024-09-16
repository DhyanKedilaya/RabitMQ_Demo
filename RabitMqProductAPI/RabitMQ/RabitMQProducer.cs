using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabitMqProductAPI.RabitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendProductMessage <T> (T message)
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            //Create the RabbitMQ connection using connection factory details as mentioned above
            var connection = factory.CreateConnection();

            //creation of channel with session and model
            using var channel = connection.CreateModel();

            //declare the queue after mentioning name and a property related to that
            channel.QueueDeclare("product", exclusive: false);

            //Serialize the message i.e convert to json format(this step is to put the json data in the queue)
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the product queue
            channel.BasicPublish(exchange: "", routingKey: "product", body: body);

        }
    }
}
