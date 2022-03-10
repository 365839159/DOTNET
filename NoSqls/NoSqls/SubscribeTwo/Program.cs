using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory()
{
    Uri = new Uri("amqp://admin:admin@192.168.65.133:5672"),
    AutomaticRecoveryEnabled = true
};
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    //创建交换机
    var exchange = "HuaWeiP30";
    channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Fanout);
    //生成队列
    var queueName = channel.QueueDeclare("SubscribeTwo").QueueName;
    channel.QueueBind(queue: queueName,
                      exchange: exchange,
                      routingKey: "");

    Console.WriteLine($"{queueName}: Waiting for HuaWeiP30.");

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($"{queueName}: {message}");
        Console.WriteLine($"{queueName}: 我要批发10000台");
    };
    channel.BasicConsume(queue: queueName,
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine("按任意键退出！");
    Console.ReadLine();
}