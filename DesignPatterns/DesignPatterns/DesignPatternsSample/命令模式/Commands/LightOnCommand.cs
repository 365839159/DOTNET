using DesignPatternsSample.命令模式.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.命令模式.Commands
{
    //这是一个命令
    public class LightOnCommand : ICommand
    {
        Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            this.light.On();
        }

        public void Undo()
        {
            this.light.Off();
        }
    }
}
