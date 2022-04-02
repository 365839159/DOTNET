using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.工厂模式.简单工厂.披萨
{
    public class Pizza
    {
        protected string name;
        protected string dough;
        protected string sauce;

        protected ArrayList toppings = new ArrayList();
        public void Prepare()
        {
            Console.WriteLine($"prepare : {name}");
            Console.WriteLine($"tossing dough : {dough}");
            Console.WriteLine($"add sauce  : {sauce}");
            Console.WriteLine($"assing toppings  :");
            for (int i = 0; i < toppings.Count; i++)
            {
                Console.WriteLine(toppings[i]);
            }
        }
        public void Bake()
        {
            Console.WriteLine($"back for 25 minutes at 350  :");
        }
        public void Cut() {

            Console.WriteLine($"cutting the pizza into diagonal slices");
        }
        public void Box() {
            Console.WriteLine($"place pizza inofficial pizzaStore box");
        }
    }
}
