using DesignPatternsSample.命令模式.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.命令模式.Commands
{
    public class LightOffCommand : ICommand
    {
        Light light;
        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            this.light.Off();
        }
    }
}
