using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.命令模式
{
    public class SimpleRemoteControl
    {
        //单个命令保存
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }
        public void ButtonWasPressed()
        {
            command.Execute();
        }
    }
}
