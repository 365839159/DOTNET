using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.观察者模式
{
    public interface Subject
    {
        void RegisterObserver(Observer observer);//注册观察者
        void RemoveObserver(Observer observer);//移除观察者
        void NotifyObserver();//通知观察者
    }
}
