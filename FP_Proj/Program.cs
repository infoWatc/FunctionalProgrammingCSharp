using System;
using static System.Math;

// Funcitonal Programming in
// How to write better C# code
// Exercise 1.22

namespace FP_Proj
{
    public class Circle
    {
        // A getter-only auto-property can
        // be set only in the constructor or inline:

        public Circle(double radius) => Radius = radius;
        // Property - Getter-only auto-properties
        // facilitate the definition of immutable types
        public double Radius { get; }

        //Expresion-bodied property
        public double Circumference => PI * 2 * Radius;

        // A local functiion is a method declared with 
        // another method
        public double Area
        {
            //  C# 7 allows you to make this explicit by declaring
            //  methods within the scope of a method; for instance,
            //  the Square method is declared within the scope of
            //  the Area getter:
            get
            {
                static double Square(double d) => Pow(d, 2);
                return PI * Square(Radius);
            }
        }

        //C# 7 tuple syntax with named elements
        public (double Circumferance, double Area) Stats => (Circumference, Area);
        // End of exercise page 12
    }

    // myCode : output exercise from book    
    internal class Program
    {
        //Validation
        private static bool IsValid(string numberText, ref double number)
        {
            bool value = double.TryParse(numberText, out number);
            return value;
        }

        // Main
        static void Main()
        {       
            // Vaariable number
            double number = 0.0;

            Console.Write("Please enter the radius of the circle: ");
            string passThisNumber = Console.ReadLine();

            do
            {
                if (IsValid(passThisNumber, ref number) == true)
                {
                    Circle circle = new Circle(number);
                    // Var 
                    var theOutup = (radius: "The Radius is: ",
                                  circumference: "The Circumference is: ",
                                  area: "The area is: ");

                    Console.WriteLine(theOutup.radius + circle.Radius);
                    Console.WriteLine(theOutup.circumference + circle.Circumference);
                    Console.WriteLine(theOutup.area + circle.Area);
                }
                else
                {
                    Console.WriteLine("Enter a valid number");
                }

                Console.Write(@"Please enter the radius of the circle < 'x' exits>: ");
                passThisNumber = Console.ReadLine();

            } while (passThisNumber != "x");

            Console.WriteLine("End of program");
        }
    }

    /*Console Output:

    Please enter the radius of the circle: 55
    The Radius is: 55
    The Circumference is: 345.57519189487726
    The area is: 9503.317777109125
    Please enter the radius of the circle < 'x' exits>: 33
    The Radius is: 33
    The Circumference is: 207.34511513692635
    The area is: 3421.194399759285
    Please enter the radius of the circle < 'x' exits>: 1
    The Radius is: 1
    The Circumference is: 6.283185307179586
    The area is: 3.141592653589793
    Please enter the radius of the circle < 'x' exits>: dd
    Enter a valid number
    Please enter the radius of the circle < 'x' exits>: 3s
    Enter a valid number
    Please enter the radius of the circle < 'x' exits>: 5
    The Radius is: 5
    The Circumference is: 31.41592653589793
    The area is: 78.53981633974483
    Please enter the radius of the circle < 'x' exits>: x
    End of program

                                                 */
}
