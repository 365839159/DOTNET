using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.模板方法
{
    /// <summary>
    /// 咖啡因饮料抽象类
    /// </summary>
    public abstract class CaffeineBeverage
    {
        #region
        /*
         * PrepareRecipe 是我们的模板方法
         * 1、用作一个算法的模板
         * 2、通用方法是由这个类处理的（BoilWater PourInCup）
         * 3、某些方法是由子类处理的（Brew AddCondiments）
         * 4、需要由子类提供的方法，必须在超类中声明为抽象
         */
        #endregion
        public void PrepareRecipe()
        {
            BoilWater();//烧水
            Brew();//酿造
            PourInCup();//装杯
            if (Hook()) AddCondiments();//添加适当的调料
        }

        private void BoilWater()
        {
            Console.WriteLine("Boiling Water");
        }
        internal abstract void Brew();


        private void PourInCup()
        {
            Console.WriteLine("Pouring into cup");
        }

        internal abstract void AddCondiments();

        internal virtual bool Hook()
        {
            return false;
        }
    }
}
