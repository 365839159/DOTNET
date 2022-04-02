#region 创建型

//单例
//SingletonPattern.Call.Show();

//建造者
//BuilderPattern.Call.Show();

#endregion




using DesignPatternsSample.工厂模式.工厂模式;
using DesignPatternsSample.工厂模式.工厂模式.Store;
using DesignPatternsSample.策略模式.DuckDemo;
<<<<<<< HEAD
using DesignPatternsSample.观察者模式;
#region ==策略模式==
=======
using DesignPatternsSample.策略模式.LoginDemo.Enum;
using DesignPatternsSample.策略模式.LoginDemo.Factory;
using DesignPatternsSample.策略模式.LoginDemo.Login;

>>>>>>> 65342ec59c41ce9f4e04676397e8182b87974a55
//List<Duck> ducks = new List<Duck>() { new ReadDuck(), new BlackDuck(), new RubberDuck() };
//foreach (var duck in ducks)
//{
//    duck.Display();
//    duck.Swim();
//    duck.Quack();
//    duck.Fly();
//    Console.WriteLine();
//}

<<<<<<< HEAD


#endregion


#region 观察者模式

//WeaterData weaterData = new WeaterData();

//CurrentConditionsDisplay CurrentConditionsDisplay =new CurrentConditionsDisplay(weaterData);


//weaterData.SetMeasurements(28, 55, 30.4);


#endregion
=======
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
>>>>>>> 65342ec59c41ce9f4e04676397e8182b87974a55


#region 工厂模式
Console.WriteLine("NYStylePizzaStore Cheese ");
PizzaStore pizzaStore = new NYStylePizzaStore();
var pizza = pizzaStore.OrderPizza(DesignPatternsSample.工厂模式.简单工厂.PizzaType.Cheese);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("ChicagoStylePizzaStore Cheese ");
PizzaStore pizzaStore1 = new ChicagoStylePizzaStore();
var pizza1 = pizzaStore.OrderPizza(DesignPatternsSample.工厂模式.简单工厂.PizzaType.Cheese);


#endregion
Console.ReadKey();