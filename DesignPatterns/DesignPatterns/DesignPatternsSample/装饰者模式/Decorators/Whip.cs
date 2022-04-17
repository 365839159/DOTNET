using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.装饰者模式.Decorators
{
    public class Whip : CondimentDecorator
    {
        public Beverage Beverage { get; set; }

        public Whip(Beverage beverage)
        {
            Beverage = beverage;
        }

        public override double Cost()
        {
            return Beverage.Cost() + .40;
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + ", Whip";
        }
    }
}
