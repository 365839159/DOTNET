using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.工厂模式.简单工厂.披萨
{
    public class NYCheese : Pizza
    {
        public NYCheese()
        {
            this.name = "NY Style sauce and cheese pizza";
            dough = "thin crust dough";
            sauce = "Marinara sauce";

            toppings.Add("Grated Reggiano Cheese");
        }
    }
}
