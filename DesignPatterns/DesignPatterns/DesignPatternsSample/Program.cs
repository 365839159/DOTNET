#region 创建型

//单例
//SingletonPattern.Call.Show();

//建造者
//BuilderPattern.Call.Show();

#endregion



#region ==策略模式==
using DesignPatternsSample.策略模式.DuckDemo;
using DesignPatternsSample.策略模式.LoginDemo.Enum;
using DesignPatternsSample.策略模式.LoginDemo.Factory;
using DesignPatternsSample.策略模式.LoginDemo.Login;

//List<Duck> ducks = new List<Duck>() { new ReadDuck(), new BlackDuck(), new RubberDuck() };
//foreach (var duck in ducks)
//{
//    duck.Display();
//    duck.Swim();
//    duck.Quack();
//    duck.Fly();
//    Console.WriteLine();
//}

while (true)
{
    Console.WriteLine("请输入登录方式：1(account) 、2(phone) 、3(email)");
    //Console.WriteLine("请输入登录方式：1(account) 、2(email) 、3(sms)、 4(Other)");
    UserLoginMode userLoginMode = (UserLoginMode)Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("请输入登录code：");
    string code = Console.ReadLine();
    Console.WriteLine("请输入登录password：");
    string password = Console.ReadLine();
    var userLogin = UserLoginCheckFactory.CreateUserLogin(userLoginMode);
    UserLoginContext context = new UserLoginContext();
    context .SetUserLoginStrategy(userLogin);
    var message = context.Login(code, password);
    Console.WriteLine($" Status ：{message.Status}            Message：{message.Message}");
    Console.ReadKey();
}




#endregion
Console.ReadKey();