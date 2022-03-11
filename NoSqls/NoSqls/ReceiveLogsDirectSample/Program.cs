using RabbitMQ.Client;


var factory = new ConnectionFactory()
{
    Uri = new Uri("amqp://admin:admin@192.168.65.133:5672"),
    AutomaticRecoveryEnabled = true
};
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    //声明交换机
    string exchange = "direct_log";
    channel.ExchangeDeclare(exchange: exchange, ExchangeType.Direct);
    //声明随机队列
    var queueName = channel.QueueDeclare().QueueName;
    foreach (var severity in args)
    {
        channel.QueueBind(queueName, exchange, severity);
    }
    Console.WriteLine($"绑定完成！{string.Join(',', args)}");
    var consumer = new RabbitMQ.Client.Events.EventingBasicConsumer(channel);
    //事件
    consumer.Received += (model, ea) =>
    {
        byte[] body = ea.Body.ToArray();
        string message = System.Text.Encoding.UTF8.GetString(body);
        var routingKey = ea.RoutingKey;
        Console.WriteLine("消费 '{0}':'{1}'", routingKey, message);
    };
    //消费
    channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
    Console.WriteLine("任意键退出！");
    Console.ReadLine();

}