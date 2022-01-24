using System;
using RabbitMQ.Client;
using System.Text;

Console.WriteLine("请输入要发送的内容！");
string content = String.Empty;
while ((content = Console.ReadLine()) != "q")
{
    var factory = new ConnectionFactory() { HostName = "localhost" };
    using (var connection = factory.CreateConnection())
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "task_queue",
                             durable: true,//可持久化
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var message = content;
        var body = Encoding.UTF8.GetBytes(message);

        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(exchange: "",
                             routingKey: "task_queue",
                             basicProperties: properties,
                             body: body);
        Console.WriteLine(" [x] Sent {0}", message);
    }
}
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();


//static string GetMessage(string[] args)
//{
//    return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
//}
