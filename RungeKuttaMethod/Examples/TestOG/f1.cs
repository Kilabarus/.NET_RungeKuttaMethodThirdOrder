using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class f1 : IFunction
    {
        public double Value(double x, Vector y = null)
        {
            return y[1] * y[1] * y[2];
        }
    }
}
