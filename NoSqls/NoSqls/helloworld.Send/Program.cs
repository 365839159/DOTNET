using RabbitMQ.Client;
using System.Text;


Console.WriteLine("请输入要发送的内容！");
string content;
while ((content = Console.ReadLine()) != "q")
{
    //连接工厂
    var factory = new ConnectionFactory() { HostName = "localhost" };
    //通过连接工厂创建连接
    using (var connection = factory.CreateConnection())
    //创建信道
    using (var channel = connection.CreateModel())
    {
        //定义队列
        channel.QueueDeclare(queue: "hello",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
        //将消息转换为二进制数据
        string message = content;
        var body = Encoding.UTF8.GetBytes(message);
        //发布
        channel.BasicPublish(exchange: "",
                             routingKey: "hello",
                             basicProperties: null,
                             body: body);
        Console.WriteLine(" [x] Sent {0}", message);
    }
    Console.WriteLine("请输入要发送的内容！");
}
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();