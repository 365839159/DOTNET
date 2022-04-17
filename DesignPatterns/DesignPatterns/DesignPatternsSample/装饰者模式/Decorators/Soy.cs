using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.装饰者模式.Decorators
{
    public class Soy : CondimentDecorator
    {
        public Beverage Beverage { get; set; }

        public Soy(Beverage beverage)
        {
            Beverage = beverage;
        }

        public override double Cost()
        {
            return Beverage.Cost() + .30;
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + ", Soy";
        }
    }
}
