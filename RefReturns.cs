using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesCSharp7
{
    public class RefReturns
    {
        static ref int Find(int[] numbers, int value)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == value)
                    return ref numbers[i];
            }

            //cannot do this by value return
            //return -1;

            //cannot return a local
            //int fail = -1;
            //return ref fail;

            throw new ArgumentException("meh");
        }

        static ref int Min(ref int x, ref int y)
        {
            //return x<y?(ref x):(ref y);
            //return ref(x<y?x:y);
            if (x < y) return ref x;
            return ref y;
        }

        static void MainR(string[] args)
        {
            //reference to a local variable
            int[] numbers = {1, 2, 3};
            ref int refToSecond = ref numbers[1];
            var valueOfSecond = refToSecond;

            //cannot rebind 
            //refToSecond = ref numbers[0];

            refToSecond = 123;
            Console.WriteLine(string.Join(",", numbers)); //1,123,3

            //reference persists even after the array is resized
            Array.Resize(ref numbers, 1);
            Console.WriteLine($"second = {refToSecond}, Array size is {numbers.Length}");

            refToSecond = 123;
            Console.WriteLine($"second = {refToSecond}, Array size is {numbers.Length}");

            //numbers.SetValue(321, 1);
            //will throw exception as the array length is just 1 but still allowing the ref to use the more than 1st index, its a kind of hack for the ref

            //Won't work with lists
            var numberList = new List<int>{1, 2, 4};
            //ref int second = ref numbersList[1]; //property or indexer cannot be out

            int[] moreNumbers = {10, 20, 30};
            //ref int refToThirty = ref Find(moreNumbers, 30);
            //refToThirty = 1000;

            Console.WriteLine(string.Join(",", moreNumbers));

            //too many references
            int a = 1, b = 2;
            ref var minRef = ref Min(ref a, ref b);

            //non-ref call just gets the value
            int minValue = Min(ref a, ref b);
            Console.WriteLine($"min is {minValue}");

        }
    }
}
