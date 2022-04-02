using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.观察者模式
{
    public interface Observer
    {
        void Update(double v, double humidity, double pressure);// 修改观察者数据
    }
}
