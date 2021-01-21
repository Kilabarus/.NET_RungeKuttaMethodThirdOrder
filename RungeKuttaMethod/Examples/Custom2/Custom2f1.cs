using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class Custom2f1 : IFunction
    {
        public double Value(double x, Vector args = null)
        {
            return -2 * args[1] + 4 * args[2];
        }
    }
}
