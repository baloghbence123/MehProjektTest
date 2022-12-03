using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehProjektTest.Helpers
{
    public class AgingCalculator
    {
        public static int Chance(int age)
        {
            return (int)Math.Pow(Math.E, (age / 30));
        }
    }
}
