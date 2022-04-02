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