using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.模板方法.duckSort
{
    public class Duck : IComparable<Duck>
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public Duck(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"{Name}  weighs {Weight}";
        }
        public int CompareTo(Duck? other)
        {
            if (other == null)
                throw new ArgumentNullException("other is null");
            if (this.Weight < other.Weight)
            {
                return -1;
            }
            else if (this.Weight == other.Weight)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
