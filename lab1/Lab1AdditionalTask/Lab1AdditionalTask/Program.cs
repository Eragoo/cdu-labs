using System;
using Additional;

namespace Lab1AdditionalTask
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestTriangleGetArea();
            TestTriangleGetPerimeter();
            TestTriangleSetIncorrectValue();
            TestTriangleInitializationWithIncorrectSides();
            TestTriangleInitializationWithNegativeSide();
        }

        public static void TestTriangleInitializationWithNegativeSide()
        {
            try
            {
                TTriangle t = new TTriangle(-1, 1, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine("✅ TestTriangleInitializationWithNegativeSide passed");
                return;
            }
            Console.WriteLine("🚫 TestTriangleInitializationWithNegativeSide FAILED");
        }

        public static void TestTriangleInitializationWithIncorrectSides()
        {
            try
            {
                TTriangle t = new TTriangle(100, 1, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine("✅ TestTriangleInitializationWithIncorrectSides passed");
                return;
            }
            Console.WriteLine("🚫 TestTriangleInitializationWithIncorrectSides FAILED");
        }

        public static void TestTriangleSetIncorrectValue()
        {
            try
            {
                TTriangle t = new TTriangle(1, 1, 1);
                t.SetA(100);
            }
            catch (Exception e)
            {
                Console.WriteLine("✅ TestTriangleSetIncorrectValue passed");
                return;
            }
            Console.WriteLine("🚫 TestTriangleSetIncorrectValue FAILED");
        }

        public static void TestTriangleGetPerimeter()
        {
            long expected = 3;
            TTriangle t = new TTriangle(1, 1, 1);
            double actual = t.GetPerimeter();

            if (Math.Abs(expected - actual) < 0.0001)
            {
                Console.WriteLine("✅ TestTriangleGetPerimeter passed");
            }
            else
            {
                Console.WriteLine("🚫 TestTriangleGetPerimeter FAILED");
            }
        }

        public static void TestTriangleGetArea()
        {
            double expected = 6;
            TTriangle t = new TTriangle(3, 4, 5);
            double actual = t.GetArea();

            if (Math.Abs(expected - actual) < 0.0001)
            {
                Console.WriteLine("✅ TestTriangleGetArea passed");
            }
            else
            {
                Console.WriteLine("🚫 TestTriangleGetArea FAILED");
            }
        }
    }
}