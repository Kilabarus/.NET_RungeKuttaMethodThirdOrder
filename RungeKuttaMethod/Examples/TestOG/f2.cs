using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class f2 : IFunction
    {
        public double Value(double x, Vector y = null)
        {
            return (y[2] / x) - (y[1] * y[2] * y[2]);
        }
    }
}
