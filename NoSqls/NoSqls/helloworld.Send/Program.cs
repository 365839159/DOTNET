using RabbitMQ.Client;
using System.Text;




//创建连接的工厂（指定连接参数）
var factory = new ConnectionFactory()
{
    HostName = "192.168.65.133",
    UserName = "admin",
    Password = "admin",
    Port = 5672
};
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
    Console.WriteLine("生产者准备就绪");
    Console.WriteLine("请输入要发送的内容！");
    string content;
    while ((content = Console.ReadLine()) != "q")
    {
        //将消息转换为二进制数据
        string message = content;
        var body = Encoding.UTF8.GetBytes(message);
        //发布
        channel.BasicPublish(exchange: "",
                             routingKey: "hello",
                             basicProperties: null,
                             body: body);
        Console.WriteLine($" {DateTime.Now}:");
        Console.WriteLine($" Send: {message}");
        Console.WriteLine("请输入要发送的内容！");
    }
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();