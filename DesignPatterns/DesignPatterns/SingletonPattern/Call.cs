using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class Call
    {
        public static void Show()
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => { var instance = SingletonSample.GetInstance(); instance.Show(); });
            }
        }
    }
}
