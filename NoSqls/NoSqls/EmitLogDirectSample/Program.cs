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
    //声明交换机
    string exchange = "direct_log";
    channel.ExchangeDeclare(exchange: exchange,
                            ExchangeType.Direct);


    string[] severityList = new string[] { "error", "info", "warning" };
    Random random = new Random();
    while (true)
    {
        var index = random.Next(0, severityList.Length);
        string severity = severityList[index];
        var message = severity + "----------" + DateTime.Now.ToString();
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: exchange,
                             routingKey: severity,
                             basicProperties: null,
                             body: body);
        Console.WriteLine("发送 '{0}':'{1}'", severity, message);

        Task.Delay(1000).Wait();
    }

}

