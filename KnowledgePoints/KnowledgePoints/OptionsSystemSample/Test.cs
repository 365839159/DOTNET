using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsSystemSample
{

    public class Test
    {
        private readonly IOptionsSnapshot<Config> _config;

        public Test(IOptionsSnapshot<Config> config)
        {
            _config = config;
        }

        public void Print()
        {
            Console.WriteLine(_config.Value.Name);
        }
    }
}
