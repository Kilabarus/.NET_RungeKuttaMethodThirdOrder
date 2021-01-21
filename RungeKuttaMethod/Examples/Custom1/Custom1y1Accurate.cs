using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class Custom1y1Accurate : IFunction
    {
        public double Value(double x, Vector args = null)
        {
            return (x * x * x * Math.Exp(x * x * x)) / 3;
        }
    }
}
