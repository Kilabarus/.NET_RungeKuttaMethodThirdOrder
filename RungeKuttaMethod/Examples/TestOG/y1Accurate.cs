using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class y1Accurate : IFunction
    {
        public double Value(double x, Vector args = null)
        {
            return 0.5 * Math.Exp(0.25 * (x * x - 1));
        }
    }
}
