using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OptionsSystemSample;

#region 创建读取对象
//Microsoft.Extensions.Configuration
//Microsoft.Extensions.Configuration.Json

ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("Config.json", optional: true, reloadOnChange: true);
var configurationRoot = configurationBuilder.Build();
#endregion

#region 读取节点下的值

// string name = configurationRoot["Name"];
//
// string age = configurationRoot["Age"];
// string identity = configurationRoot.GetSection("Proxy:Identity").Value;
//
// Console.WriteLine($"{name},{age},{identity}");

#endregion


#region 最佳实战

//Microsoft.Extensions.Options

ServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<Test>();
serviceCollection.AddOptions().Configure<Config>(s => configurationRoot.Bind(s));
using (var provider = serviceCollection.BuildServiceProvider())
{
    var testInstance = provider.GetService<Test>();
    if (testInstance is not null)
    {
        testInstance.Print();
    }
}

#endregion

#region 类模式

//Microsoft.Extensions.Configuration.Binder
// var proxy = configurationRoot.GetSection("Proxy").Get<Proxy>();
// Console.WriteLine($"{proxy.Address},{proxy.Identity}");
// var config = configurationRoot.Get<Config>();
// Console.WriteLine($"{config.Name},{config.Age},{config.Proxy.Address}");

public
    class Proxy
{
    public string? Identity { get; set; }
    public string? Address { get; set; }
}

public class Config
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public Proxy? Proxy { get; set; }
}

#endregion