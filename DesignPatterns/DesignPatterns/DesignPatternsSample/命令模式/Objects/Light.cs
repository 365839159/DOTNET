using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.命令模式.Objects
{
    //具体操作对象
    public class Light
    {
        public void On() { Console.WriteLine("light on"); }
        public void Off() { Console.WriteLine("light off"); }
    }
}
