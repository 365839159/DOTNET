using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Home
    {
        private string _type;
        public Home(string type)
        {
            this._type = type;
        }

        public void Play()
        {
            Console.WriteLine($"欢迎来{this._type}家玩");
        }

    }
}
