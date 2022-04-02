using DesignPatternsSample.工厂模式.简单工厂;
using DesignPatternsSample.工厂模式.简单工厂.披萨;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.工厂模式.工厂模式
{
    public abstract class PizzaStore
    {
        public Pizza OrderPizza(PizzaType pizzaType)
        {
            var pizza = CreatePizza(pizzaType);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }


        protected abstract Pizza CreatePizza(PizzaType pizzaType);
    }
}
