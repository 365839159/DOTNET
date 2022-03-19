using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.策略模式.DuckDemo
{
    internal class RubberDuck : Duck
    {
        public override void Display()
        {
            Console.WriteLine("我是橡皮鸭");
        }
    }
}
