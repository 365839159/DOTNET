using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.命令模式.Commands
{
    public class MacroCommand : ICommand
    {
        ICommand[] commands;

        public MacroCommand(params ICommand[] commands)
        {
            this.commands = commands;
        }

        public void Execute()
        {
            foreach (var item in commands)
                item.Execute();
        }

        public void Undo()
        {
            var items = commands.Reverse();
            foreach (var item in items)
                item.Undo();
        }
    }
}
