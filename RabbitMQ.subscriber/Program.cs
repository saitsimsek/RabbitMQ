

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://hlhvpexd:8tyFLTYa1wv1adchaD25UOMlJkS7njzJ@shrimp.rmq.cloudamqp.com/hlhvpexd");
using  var connection = factory.CreateConnection();
var channel = connection.CreateModel();

//channel.QueueDeclare("hello-queue",true,false,false);
channel.BasicQos(0,1,true);
var consumer = new EventingBasicConsumer(channel);

channel.BasicConsume("hello-queue",false,consumer);

consumer.Received += (object? sender, BasicDeliverEventArgs e)=>
{
    var message = Encoding.UTF8.GetString(e.Body.ToArray());
    Console.WriteLine("Gelen Mesaj: "+message);
    channel.BasicAck(e.DeliveryTag,false);
};


Console.ReadLine();

