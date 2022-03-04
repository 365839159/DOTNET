using System;
using RabbitMQ.Client;
using System.Text;


var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://admin:admin@192.168.65.133:5672"),
    AutomaticRecoveryEnabled = true
};
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "task_queue",
                         durable: true,//可持久化
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
    int count = 0;
    while (true)
    {
        count++;
        var message = $"Task {count}";
        var body = Encoding.UTF8.GetBytes(message);

        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(exchange: "",
                             routingKey: "task_queue",
                             basicProperties: properties,
                             body: body);
        Console.WriteLine("Send {0}", message);
        //暂停一秒
        Task.Delay(1000).Wait();
    }
}

