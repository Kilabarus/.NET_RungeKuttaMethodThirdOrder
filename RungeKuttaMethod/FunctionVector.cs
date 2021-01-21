using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class FunctionVector
    {
        IFunction[] _functions;

        public FunctionVector(int size)
        {
            _functions = new IFunction[size];
            Length = size;
        }

        public int Length { get; private set; }        

        public IFunction this[int i]
        {
            get
            {
                return _functions[i - 1];
            }

            set
            {
                _functions[i - 1] = value;
            }
        }

        public Vector Value(double x, Vector y)
        {
            Vector resVector = new Vector(Length);

            for (int i = 1; i <= Length; ++i)
            {
                resVector[i] = this[i].Value(x, y);
            }

            return resVector;
        }
    }
}
