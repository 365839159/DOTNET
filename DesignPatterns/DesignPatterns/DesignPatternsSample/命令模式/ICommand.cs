using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.命令模式
{
    //命令对象基类
    public interface ICommand
    {
        public void Execute();
    }
}
