using DesignPatternsSample.工厂模式.简单工厂.披萨;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.工厂模式.简单工厂
{
    public class PizzaStore
    {
        public PizzaStore()
        {

        }
        public Pizza OrderPizza(PizzaType pizzaType)
        {
            var pizza = SimplePizzaFactory.CreatePizza(pizzaType);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }
    }
}
