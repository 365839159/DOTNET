using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.装饰者模式
{
    /// <summary>
    /// 抽象组件
    /// </summary>
    public abstract class Beverage
    {
        public string description = "Unknow Beverage";
        public abstract string GetDescription();
        //{
        //    return description;
        //}
        public abstract double Cost();
    }
}
