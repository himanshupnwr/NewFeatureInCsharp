using System;

namespace NewFeaturesCSharp
{
    class OutVariables
    {
        static void Main(string[] args)
        {
            DateTime dt;
            if (DateTime.TryParse("01/01/2017", out dt))
            {
                Console.WriteLine($"Old-fashioned parse: {dt}");
            }

            //variable declaration is an expression, not a statement 
            if (DateTime.TryParse("02/02/2016", out var dt2))
            {
                Console.WriteLine($"New Parse: {dt2}");
            }

            //the scope of dt2 extends outside the if block 
            Console.WriteLine($"I can use dt2 here : {dt2}");

            //what if the parse fails then the output will be the default value of the type in which we were trying to convert
            int.TryParse("abc", out var i);
            Console.WriteLine($"i = {i}"); //default value
        }
    }
}
