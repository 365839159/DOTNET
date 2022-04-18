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
        ICommand undoCommand;
        public RemoteControl()
        {
            onCommand = new ICommand[100];
            offCommand = new ICommand[100];
            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 100; i++)
            {
                onCommand[i] = noCommand;
                offCommand[i] = noCommand;
            }
            undoCommand = noCommand;
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            this.onCommand[slot] = onCommand;
            this.offCommand[slot] = offCommand;
        }
        public void OnButtonWasPushed(int slot)
        {
            this.onCommand[slot].Execute();
            undoCommand = this.onCommand[slot];
        }

        public void OffButtonWasPushed(int slot)
        {
            this.offCommand[slot].Execute();
            undoCommand = this.offCommand[slot];
        }
        public void UndoButtonWasPushed()
        {
            this.undoCommand.Undo();
        }
    }
}
