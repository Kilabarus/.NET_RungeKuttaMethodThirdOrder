using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class Custom1f1 : IFunction
    {
        public double Value(double x, Vector args = null)
        {            
            return 3 * x * x * args[1] + x * x * Math.Exp(x * x * x);
        }
    }
}
