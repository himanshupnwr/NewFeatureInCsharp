using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesCSharp
{
    public class Deconstruction
    {
        static void mainD(string[] args)
        {
            var myPoint = new DeconPoint();
            var (x, _) = myPoint;
            Console.WriteLine($"{x}");
        }
    }

    public class DeconPoint
    {
        public int X, Y;

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}
