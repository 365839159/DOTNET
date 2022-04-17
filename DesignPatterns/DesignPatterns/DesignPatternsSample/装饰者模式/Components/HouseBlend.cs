using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.装饰者模式.Components
{
    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            description = "House Blend Coffee";
        }

        public override double Cost()
        {
            return .89;
        }

        public override string GetDescription()
        {
           return description;
        }
    }
}
