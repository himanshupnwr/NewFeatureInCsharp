using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesCSharp
{

    public class Point
    {
        public int X, Y;

        public void Deconstruct(out string s)
        {
            s = $"{X}-{Y}";
        }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
    public class Tuples
    {
        static Tuple<double, double> SumAndProduct(double a, double b)
        {
            return Tuple.Create(a + b, a * b);
        }

        //requires ValueTuple nuget package for C# 7.0
        //originally with no names
        static (double sum, double product) NewSumAndProduct(double a, double b)
        {
            return (a + b, a * b);
        }

        static void MainT(string[] args)
        {
            //New
            var sp = SumAndProduct(2, 5);
            //sp.Item1 looks ugly
            Console.WriteLine($"sum = {sp.Item1}, product = {sp.Item2}");

            var sp2 = NewSumAndProduct(2, 4);
            Console.WriteLine($"new sum = {sp2.sum}, product = {sp2.product}");
            Console.WriteLine($"Item1 = {sp2.Item1}");
            Console.WriteLine(sp2.GetType());

            //Converting to valueTuple loses all info
            var vt = sp2;
            //back to Item1, Item2, etc...
            var item1 = vt.Item1;
            //can use var
            var (sum, product) = NewSumAndProduct(3, 5);

            //note - var works but double doesn't
            //double (s,p) = NewSumAndProduct(3,4);

            Console.WriteLine($"sum = {sum}, product = {product}");
            Console.WriteLine(sum.GetType());

            //also assignment
            double s, p;
            (s, p) = NewSumAndProduct(1, 10);

            //tuple declarations with names
            //var me = new { name = "Himanshu", age = 32); //Anonymous Type

            var me = (name: "Himanshu", age: 32);
            Console.WriteLine(me);
            Console.WriteLine(me.GetType());

            //names are not part of type
            Console.WriteLine("Fields:" + string.Join(",", me.GetType().GetFields().Select(pr=>pr.Name)));
            Console.WriteLine("Properties: " + string.Join(",", me.GetType().GetProperties().Select(pr => pr.Name)));
            Console.WriteLine($"My Name is {me.name} and I am {me.age} years old");
            //proceed to show return: TupleElementNames in dotpeek (internally item1 and item2 are used everywhere)

            //unfortunately, tuple names only propagate out a function if they're in the signature
            var snp = new Func<double, double, (double sum, double product)>((a, b) => (sum: a + b, product: a * b));
            var result = snp(1, 2);
            //there's no result.sum unless you add it to signature
            Console.WriteLine($"sum = {result.sum}");

            //deconstruction
            Point pt = new Point() {X = 2, Y = 3};

            var (x, y) = pt; // interesting error here
            Console.WriteLine($"Got a point x={x}, y={y}");

            //can also discard values by using _ underscore 
            (int z, _) = pt;
        }
    }
}
