using RabbitMQ.Client;
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
    var message = "HuaWeiP30到货了";
    var body = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(
        exchange: exchange,
        routingKey: "",
        basicProperties: null,
        body: body);
    Console.WriteLine($"Send : {message}");
    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}



