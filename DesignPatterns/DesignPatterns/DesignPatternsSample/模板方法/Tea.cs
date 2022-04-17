using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.模板方法
{
    public class Tea : CaffeineBeverage
    {
        internal override void AddCondiments()
        {
            Console.WriteLine("Adding Lemon");//Lemon :柠檬
        }

        internal override void Brew()
        {
            Console.WriteLine("Steeping the tea");
        }
    }
}
