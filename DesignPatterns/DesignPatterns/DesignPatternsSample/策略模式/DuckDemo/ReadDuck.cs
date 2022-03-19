using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.策略模式.DuckDemo
{
    public class ReadDuck : Duck
    {
        public override void Display()
        {
            Console.WriteLine("我是红鸭");
        }
    }
}
