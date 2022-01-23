using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Home2 : IHomeBuilder
    {
        private readonly Home _home;

        public Home2(string type)
        {
            this._home = new Home(type);
        }

        public IHomeBuilder BuildDoors()
        {
            Console.WriteLine($"buildGargen:{1}");
            return this;
        }

        public Home Builder()
        {
            return _home;
        }

        public IHomeBuilder BuildGargen()
        {
            Console.WriteLine($"buildGargen:{1}");
            return this;
        }

        public IHomeBuilder BuildRoof()
        {
            Console.WriteLine($"buildRoof:{1}");
            return this;
        }

        public IHomeBuilder BuildSwimming()
        {
            Console.WriteLine($"buildSwimming:{1}");
            return this; 
        }

        public IHomeBuilder BuildWalls()
        {
            Console.WriteLine($"BuildWalls:{4}");
            return this;
        }

        public IHomeBuilder BuildWindows()
        {
            Console.WriteLine($"BuildWindows:{2}");
            return this;
        }
    }
}
