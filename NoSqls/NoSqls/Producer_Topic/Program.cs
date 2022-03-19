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
    string[] rotuingKeys = new string[]
    {
        "bj.info", "sh.info",
        "bj.weather", "sh.weather",
        "hb.weather", "hb.wu.weather"
    };
    Random random = new Random();
    while (true)
    {
        var index = random.Next(rotuingKeys.Length);
        string rotuingKey = rotuingKeys[index];
        var message = $"{rotuingKey}-------{DateTime.Now}";
        var body = System.Text.Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange, rotuingKey, null, body);
        Console.WriteLine($"发送{rotuingKey} : {message}");
        Task.Delay(1000);
    }
}
