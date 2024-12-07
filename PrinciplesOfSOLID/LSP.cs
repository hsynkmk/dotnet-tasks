using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinciplesOfSOLID
{

    // Base class
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    #region Without LSP

    public class WrongRectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class WrongSquare : WrongRectangle
    {
        public new double Width
        {
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public new double Height
        {
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
    #endregion


    #region With LSP

    public class Rectangle(double width, double height) : Shape
    {
        public double Width { get; set; } = width;
        public double Height { get; set; } = height;

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }


    public class Square(double sideLength) : Shape
    {
        public double SideLength { get; set; } = sideLength;

        public override double CalculateArea()
        {
            return SideLength * SideLength;
        }
    }

    public class AreaCalculator
    {
        public void PrintArea(Shape shape)
        {
            Console.WriteLine($"The area of the {shape.GetType().Name} is {shape.CalculateArea()}");
        }
    }
    #endregion
}
