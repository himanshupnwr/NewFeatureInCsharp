using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesCSharp
{
    public class Shape
    {
    }

    public class Rectangle : Shape
    {
        public int Width, Height;
    }

    public class Circle : Shape
    {
        public int Diameter;
    }
    public class PatternMatching
    {
        public void DisplayShape(Shape shape)
        {
            if (shape is Rectangle)
            {
                var rc = (Rectangle) shape;
            }

            else if(shape is Circle)
            {
                //..
            }

            var rect = shape as Rectangle;
            if (rect != null)
            {
                //..
            }

            if (shape is Rectangle r )
            {
                //use r
            }

            //can also do the inverse
            if (!(shape is Circle cc))
            {
                //not a circle
            }

            switch (shape)
            {
                case Circle c:
                    //use c
                    break;
                case Rectangle sq when (sq.Width == sq.Height):
                    //square
                    break;
                case Rectangle rr:
                    //use rr
                    break;
            }

            var z = (23, 32);

            //switch (z)
            //{
            //    case (0, 0):
            //        Console.WriteLine("origin");
            //}
        }
    }
}
