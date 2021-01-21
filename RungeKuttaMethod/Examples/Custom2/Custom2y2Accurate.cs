using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class Custom2y2Accurate : IFunction
    {
        public double Value(double x, Vector args = null)
        {
            return Math.Exp(-x) - Math.Exp(2 * x);
        }
    }
}
