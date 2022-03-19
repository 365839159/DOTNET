using RabbitMQ.Client;
var factory = new ConnectionFactory()
{
    Uri = new Uri(""),
    AutomaticRecoveryEnabled = true
};
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    string exchange = "topicExchange";
    channel.ExchangeDeclare(exchange: exchange, ExchangeType.Topic);
    //声明队列
    var queueName = channel.QueueDeclare().QueueName;
    foreach (var rotuingKey in args)
    {
        channel.QueueBind(queueName, exchange, rotuingKey);
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