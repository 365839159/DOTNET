using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;


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

    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

    Console.WriteLine("Waiting for messages.");

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (sender, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("Received {0}", message);
        Task.Delay(5000).Wait();  //等待5秒
        Console.WriteLine("Task Done");

        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);//手动确认
    };
    channel.BasicConsume(queue: "task_queue",
                         autoAck: false,//关闭自动确认
                         consumer: consumer);
    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}

