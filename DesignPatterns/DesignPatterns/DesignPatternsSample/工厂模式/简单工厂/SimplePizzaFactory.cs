using DesignPatternsSample.工厂模式.简单工厂.披萨;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.工厂模式.简单工厂
{
    public class SimplePizzaFactory
    {
        public static Pizza CreatePizza(PizzaType pizzaType) =>
            pizzaType switch//享元模式
            {
                PizzaType.Cheese => new NYCheese(),
                PizzaType.Pepperoni => new NYPepperoni(),
                PizzaType.Clam => new NYClam(),
                PizzaType.Veggie => new NYVeggie()
            };
    }
}
