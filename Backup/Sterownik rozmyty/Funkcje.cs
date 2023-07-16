using System;

namespace FunkcjeR
{
    public class FunkcjeRozmyte
    {
        public FunkcjeRozmyte()
        {
        }
        public double Gamma(int x, int a, int b)
        {
            if (x <= a)
                return 0;
            else if (a < x && x <= b)
                return 1.0 * (x - a) / (b - a);
            else
                return 1;
        }
        public double L(int x, int a, int b)
        {
            if (x <= a)
                return 1;
            else if (a < x && x <= b)
                return 1.0 * (b - x) / (b - a);
            else
                return 0;
        }
        public double PI(int x, int a, int b, int c, int d)
        {
            if (x <= a)
                return 0;
            else if ((a < x) && (x <= b))
                return 1.0 * (x - a) / (b - a);
            else if ((b < x) && (x <= c))
                return 1;
            else if ((c < x) && (x < d))
                return 1.0 * (d - x) / (d - c);
            else
                return 0;
        }
    }
}
