using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.装饰者模式.Decorators
{
    public class Mocha : CondimentDecorator
    {
        public Beverage Beverage { get; set; }

        public Mocha(Beverage beverage)
        {
            Beverage = beverage;
        }

        public override double Cost()
        {
            return Beverage.Cost() + .20;
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + ", Mocha";
        }
    }
}
