using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://hlhvpexd:8tyFLTYa1wv1adchaD25UOMlJkS7njzJ@shrimp.rmq.cloudamqp.com/hlhvpexd");
using var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.QueueDeclare("hello-queue", true, false, false);

string message = "Hello world";

for (int i = 0; i < 100; i++)
{
    var messageBody = Encoding.UTF8.GetBytes(message+i);
    channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);
    Thread.Sleep(1000); 
}

//Console.WriteLine("Mesajınız gönderilmiştir.");
Console.ReadLine();

