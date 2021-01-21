using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class Vector
    {
        double[] _vector;

        public Vector(int size)
        {
            _vector = new double[size];
            Size = size;
        }

        public int Size { get; private set; }

        public double[] Array
        {
            get
            {
                return _vector;
            }

            set
            {
                _vector = (double[])value.Clone();
                Size = _vector.Length;
            }
        }

        public double this[int i]
        {
            get
            {
                return _vector[i - 1];
            }

            set
            {
                _vector[i - 1] = value;
            }
        }

        public static Vector operator *(double d, Vector v)
        {
            Vector resVector = new Vector(v.Size);

            for (int i = 1; i <= v.Size; ++i)
            {
                resVector[i] = d * v[i];
            }

            return resVector;
        }

        public static Vector operator +(Vector vL, Vector vR)
        {
            Vector resVector = new Vector(vL.Size);

            for (int i = 1; i <= vL.Size; ++i)
            {
                resVector[i] = vL[i] + vR[i];
            }

            return resVector;
        }
    }
}
