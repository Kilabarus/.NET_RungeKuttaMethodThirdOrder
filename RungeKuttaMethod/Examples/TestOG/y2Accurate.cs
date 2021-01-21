﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class y2Accurate : IFunction
    {
        public double Value(double x, Vector args = null)
        {
            return x * Math.Exp(0.25 * (1 - x * x));
        }
    }
}
