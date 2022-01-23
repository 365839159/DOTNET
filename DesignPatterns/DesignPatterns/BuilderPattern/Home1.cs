using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Home1 : IHomeBuilder
    {
        private readonly Home _home;

        public Home1(string type)
        {
            this._home = new Home(type);
        }

        public void BuildDoors()
        {
            Console.WriteLine($"buildGargen:{1}");
        }

        public Home Builder()
        {
            return _home;
        }

        public void BuildGargen()
        {
            Console.WriteLine($"buildGargen:{0}");
        }

        public void BuildRoof()
        {
            Console.WriteLine($"buildRoof:{1}");
        }

        public void BuildSwimming()
        {
            Console.WriteLine($"buildSwimming:{0}");
        }

        public void BuildWalls()
        {
            Console.WriteLine($"BuildWalls:{4}");
        }

        public void BuildWindows()
        {
            Console.WriteLine($"BuildWindows:{2}");
        }

        IHomeBuilder IHomeBuilder.BuildDoors()
        {
            throw new NotImplementedException();
        }

        IHomeBuilder IHomeBuilder.BuildGargen()
        {
            throw new NotImplementedException();
        }

        IHomeBuilder IHomeBuilder.BuildRoof()
        {
            throw new NotImplementedException();
        }

        IHomeBuilder IHomeBuilder.BuildSwimming()
        {
            throw new NotImplementedException();
        }

        IHomeBuilder IHomeBuilder.BuildWalls()
        {
            throw new NotImplementedException();
        }

        IHomeBuilder IHomeBuilder.BuildWindows()
        {
            throw new NotImplementedException();
        }
    }
}
