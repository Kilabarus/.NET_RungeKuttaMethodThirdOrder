using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public interface IFunction
    {
        double Value(double x, Vector args = null);
    }
}
