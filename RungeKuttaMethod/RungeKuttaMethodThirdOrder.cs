using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RungeKuttaMethod
{
    public class RungeKuttaMethodThirdOrder
    {
        FunctionVector f;
        public Vector[] y;
        public double[] x;
        double h;

        public void SetParameters(FunctionVector f, int N, double a, double b, Vector y0)
        {
            this.f = f;

            h = (b - a) / N;

            x = new double[N + 1];

            for (int i = 0; i <= N; ++i)
            {
                x[i] = a + i * h;
            }

            y = new Vector[N + 1];

            for (int i = 0; i < N + 1; ++i)
            {
                y[i] = new Vector(f.Length);
            }
            
            for (int i = 1; i <= f.Length; ++i)
            {
                y[0][i] = y0[i];
            }                        
        }

        public void Solve()
        {
            double
                a2 = 1.0 / 3,
                a3 = 2 * a2;                

            int
                numOfPoints = x.Length;                

            Vector 
                K1, K2, K3;                

            for (int i = 1; i < numOfPoints; ++i)
            {
                K1 = h * f.Value(x[i - 1], y[i - 1]);
                K2 = h * f.Value(x[i - 1] + a2 * h, y[i - 1] + a2 * K1);
                K3 = h * f.Value(x[i - 1] + a3 * h, y[i - 1] + a3 * K2);

                y[i] = y[i - 1] + 0.25 * (K1 + 3 * K3);
            }
        }
    }
}
