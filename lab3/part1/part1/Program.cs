using System;

namespace part1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestTriangleArea();
        }

        private static void TestTriangleArea()
        {
            Triangle a = new Triangle(new Point(1,0), new Point(2,2), new Point(0,1));
            double actual = a.GetArea();
            double expected = 1.5;
            if (isEquals(actual, expected))
            {
                Console.WriteLine("TestTriangleArea PASSED");
            }
            else
            {
                Console.WriteLine("TestTriangleArea FAILED");
            }
        }

        private static bool isEquals(double actual, double expected)
        {
            return Math.Abs(actual - expected) < 0.001;
        }
    }
}