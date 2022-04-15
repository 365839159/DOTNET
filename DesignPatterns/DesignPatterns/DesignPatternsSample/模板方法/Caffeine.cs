using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.模板方法
{
    public class Caffeine : CaffeineBeverage
    {
        internal override void AddCondiments()
        {
            Console.WriteLine("Adding sugar and milk");
        }

        internal override void Brew()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }
        internal override bool Hook()
        {
            return true;
        }
    }
}
