using DesignPatternsSample.命令模式.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.命令模式
{
    public class RemoteControl
    {
        ICommand[] onCommand;
        ICommand[] offCommand;

        public RemoteControl()
        {
            onCommand = new ICommand[100];
            offCommand = new ICommand[100];
            for (int i = 0; i < 100; i++)
            {
                onCommand[i] = new NoCommand();
                offCommand[i] = new NoCommand();
            }
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            this.onCommand[slot] = onCommand;
            this.offCommand[slot] = offCommand;
        }
        public void OnButtonWasPushed(int slot)
        {
            this.onCommand[slot].Execute();
        }

        public void OffButtonWasPushed(int slot)
        {
            this.offCommand[slot].Execute();
        }
    }
}
