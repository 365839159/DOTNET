using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.策略模式.DuckDemo
{
    public abstract class Duck
    {
        /// <summary>
        /// 叫
        /// </summary>
        public void Quack()
        {
            Console.WriteLine($"{this.GetType().Name}:嘎嘎叫");
        }
        /// <summary>
        /// 游泳
        /// </summary>
        public void Swim()
        {
            Console.WriteLine($"{this.GetType().Name}:会游泳");
        }
        /// <summary>
        /// 外貌
        /// </summary>
        public abstract void Display();

        public void Fly()
        {
            Console.WriteLine($"{this.GetType().Name}:在飞");
        }

    }
}
