using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace audio_test
{
    class vector
    {
        public double x;
        public double y;

        public vector(double dx, double dy)
        {
            x = dx;
            y = dy;
        }

        public double len()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public static vector operator /(vector a, double d)
        {
            return new vector(a.x / d, a.y / d);
        }

        public static vector operator *(vector a, double b)
        {
            return new vector(a.x * b, a.y * b);
        }

    }
}
