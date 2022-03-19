#region 创建型

//单例
//SingletonPattern.Call.Show();

//建造者
//BuilderPattern.Call.Show();

#endregion



#region ==策略模式==
using DesignPatternsSample.策略模式.DuckDemo;

List<Duck> ducks = new List<Duck>() { new ReadDuck(), new BlackDuck(), new RubberDuck() };
foreach (var duck in ducks)
{
    duck.Display();
    duck.Swim();
    duck.Quack();
    duck.Fly();
    Console.WriteLine();
}



#endregion
Console.ReadKey();