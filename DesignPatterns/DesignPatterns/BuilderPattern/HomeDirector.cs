using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    /// <summary>
    /// 指挥官
    /// </summary>
    public class HomeDirector
    {
        public void CreateCar(IHomeBuilder builder)
        {
            builder.BuildWalls().BuildRoof().BuildDoors();
            //builder.BuildRoof();
            //builder.BuildDoors();
        }
    }
}
