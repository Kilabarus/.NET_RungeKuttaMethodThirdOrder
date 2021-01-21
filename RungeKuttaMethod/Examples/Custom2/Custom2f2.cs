using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class Custom2f2 : IFunction
    {
        public double Value(double x, Vector args = null)
        {
            return -args[1] + 3 * args[2];
        }
    }
}
