using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.装饰者模式
{
    public class Espresso : Beverage
    {
        public Espresso()
        {
            description = "Espresso";
        }

        public override double Cost()
        {
            return 1.99;
        }

        public override string GetDescription()
        {
            return description;
        }
    }
}
