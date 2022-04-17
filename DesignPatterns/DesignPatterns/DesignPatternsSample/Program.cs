#region 创建型

//单例
//SingletonPattern.Call.Show();

//建造者
//BuilderPattern.Call.Show();

#endregion




using DesignPatternsSample.工厂模式.工厂模式;
using DesignPatternsSample.工厂模式.工厂模式.Store;
using DesignPatternsSample.策略模式.DuckDemo;

using DesignPatternsSample.观察者模式;
#region ==策略模式==

using DesignPatternsSample.策略模式.LoginDemo.Enum;
using DesignPatternsSample.策略模式.LoginDemo.Factory;
using DesignPatternsSample.策略模式.LoginDemo.Login;
using DesignPatternsSample.装饰者模式;
using DesignPatternsSample.装饰者模式.Components;
using DesignPatternsSample.装饰者模式.Decorators;
using DesignPatternsSample.模板方法;


//List<Duck> ducks = new List<Duck>() { new ReadDuck(), new BlackDuck(), new RubberDuck() };
//foreach (var duck in ducks)
//{
//    duck.Display();
//    duck.Swim();
//    duck.Quack();
//    duck.Fly();
//    Console.WriteLine();
//}




#endregion


#region 观察者模式

//WeaterData weaterData = new WeaterData();

//CurrentConditionsDisplay CurrentConditionsDisplay =new CurrentConditionsDisplay(weaterData);


//weaterData.SetMeasurements(28, 55, 30.4);


#endregion


#region 工厂模式


//while (true)
//{
//    Console.WriteLine("请输入登录方式：1(account) 、2(phone) 、3(email)");
//    //Console.WriteLine("请输入登录方式：1(account) 、2(email) 、3(sms)、 4(Other)");
//    UserLoginMode userLoginMode = (UserLoginMode)Convert.ToInt32(Console.ReadLine());
//    Console.WriteLine("请输入登录code：");
//    string code = Console.ReadLine();
//    Console.WriteLine("请输入登录password：");
//    string password = Console.ReadLine();
//    var userLogin = UserLoginCheckFactory.CreateUserLogin(userLoginMode);
//    UserLoginContext context = new UserLoginContext();
//    context .SetUserLoginStrategy(userLogin);
//    var message = context.Login(code, password);
//    Console.WriteLine($" Status ：{message.Status}            Message：{message.Message}");
//    Console.ReadKey();
//}





//Console.WriteLine("NYStylePizzaStore Cheese ");
//PizzaStore pizzaStore = new NYStylePizzaStore();
//var pizza = pizzaStore.OrderPizza(DesignPatternsSample.工厂模式.简单工厂.PizzaType.Cheese);
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine("ChicagoStylePizzaStore Cheese ");
//PizzaStore pizzaStore1 = new ChicagoStylePizzaStore();
//var pizza1 = pizzaStore.OrderPizza(DesignPatternsSample.工厂模式.简单工厂.PizzaType.Cheese);


#endregion


#region 装饰者模式
//一杯不要任何调料的Espresso
//Beverage espresso = new Espresso();
//Console.WriteLine($"description {espresso.GetDescription()}, $:{espresso.Cost()}");

////双 Mocha Whip  DarkRoast 
////创建对象可以使用工厂
//Beverage darkRoast = new DarkRoast();
//darkRoast = new Mocha(darkRoast);
//darkRoast = new Mocha(darkRoast);
//darkRoast = new Whip(darkRoast);
//Console.WriteLine($"description {darkRoast.GetDescription()}, $:{darkRoast.Cost()}");

////来一杯豆浆 摩卡 奶泡 HouseBlend
//Beverage houseBlend = new HouseBlend();
//houseBlend = new Soy(houseBlend);
//houseBlend = new Mocha(houseBlend);
//houseBlend = new Whip(houseBlend);
//Console.WriteLine($"description {houseBlend.GetDescription()}, $:{houseBlend.Cost()}");
#endregion


#region 模板方法

//Tea tea = new Tea();
//tea.PrepareRecipe();
//Console.WriteLine("-----------------------------------------");
//Caffeine caffeine = new Caffeine();
//caffeine.PrepareRecipe();

DesignPatternsSample.模板方法.duckSort.Duck[] ducks = {
    new DesignPatternsSample.模板方法.duckSort.Duck("Daffy", 8) ,
    new DesignPatternsSample.模板方法.duckSort.Duck("Dewey", 2) ,
    new DesignPatternsSample.模板方法.duckSort.Duck("Howard",7) ,
    new DesignPatternsSample.模板方法.duckSort.Duck("Donald", 10) ,
    new DesignPatternsSample.模板方法.duckSort.Duck("Huey", 2)
};

Console.WriteLine("Before sorting");
foreach (var item in ducks)
{
    Console.WriteLine(item.ToString());
}
Console.WriteLine("After sorting");
Array.Sort(ducks);
foreach (var item in ducks)
{
    Console.WriteLine(item.ToString());
}
#endregion



Console.ReadKey();



