//this console application acts as a RMQ client that subscribes to messages from the queue

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};

//create a connection
var connection = factory.CreateConnection();

//create channel with session and model
using var channel = connection.CreateModel();

//declare the queue after mentioning name and a related property
channel.QueueDeclare("product", exclusive:false);
//if exclusive is true, then it is only accessible by the client that declared it.
//If another client tries to access an exclusive queue, it will receive an error

//Set event object which listens to the message from the channel which is sent by producer
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Product message received: {message}");
};

// to read the message
channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
Console.ReadKey();