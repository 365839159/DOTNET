using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.装饰者模式.Components
{
    public class Decat : Beverage
    {
        public Decat()
        {
            description = "Decat";
        }

        public override double Cost()
        {
            return 3.99;
        }

        public override string GetDescription()
        {
            return description;
        }
    }
}
