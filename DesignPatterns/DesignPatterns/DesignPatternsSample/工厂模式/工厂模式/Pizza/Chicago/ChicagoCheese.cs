using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.工厂模式.简单工厂.披萨
{
    public class ChicagoCheese : Pizza
    {
        public ChicagoCheese()
        {
            this.name = "Chicago Style deep dish cheese pizza";
            dough = "Extra Thick Crust Dough";
            sauce = "Plum Tomato Sauce";

            toppings.Add("shredded Mozzarella Cheese");
        }
        new void Cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }
    }
}
