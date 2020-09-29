using System;

namespace part2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\r\nTRIANGLE TESTS: \r\n");
            TestInitIncorrectTriangle();
            TestAreaTriangle();
            TestInitCorrectTriangle();
            TestCompareEqualTriangles();
            TestMultiplyTriangles();

            Console.WriteLine("\r\nPYRAMID TESTS: \r\n");
            TestInitIncorrectPyramid();
            TestPyramidArea();
        }

        private static void TestInitIncorrectPyramid()
        {
            try
            {
                TRPiramid t = new TRPiramid(10, 2, 3, -10);
            }
            catch (Exception e)
            {
                Console.WriteLine("TestInitIncorrectPyramid PASSED");
                return;
            }

            Console.WriteLine("TestInitIncorrectPyramid FAILED");
        }

        private static void TestPyramidArea()
        {
            TRPiramid t = new TRPiramid(3, 4, 5, 10);
            double actual = t.GetArea();
            double expected = 19.9999;

            if (IsDoubleEquals(actual, expected))
            {
                Console.WriteLine("TestPyramidArea PASSED");
            }
            else
            {
                Console.WriteLine("TestPyramidArea FAILED");
            }
        }


        private static void TestInitIncorrectTriangle()
        {
            try
            {
                TRTriangle t = new TRTriangle(10, 2, 3);
            }
            catch (Exception e)
            {
                Console.WriteLine("TestInitIncorrectTriangle PASSED");
                return;
            }

            Console.WriteLine("TestInitIncorrectTriangle FAILED");
        }

        private static void TestInitCorrectTriangle()
        {
            try
            {
                TRTriangle t = new TRTriangle(3, 4, 5);
            }
            catch (Exception e)
            {
                Console.WriteLine("TestInitCorrectTriangle FAILED");
                return;
            }

            Console.WriteLine("TestInitCorrectTriangle PASSED");
        }

        private static void TestAreaTriangle()
        {
            TRTriangle t = new TRTriangle(3, 4, 5);
            double actual = t.GetArea();
            double expected = 6.0;
            if (IsDoubleEquals(actual, expected))
            {
                Console.WriteLine("TestAreaTriangle PASSED");
            }
            else
            {
                Console.WriteLine("TestAreaTriangle FAILED");
            }
        }

        private static bool IsDoubleEquals(double actual, double expected)
        {
            return Math.Abs(actual - expected) < 0.001;
        }

        private static void TestCompareEqualTriangles()
        {
            TRTriangle t1 = new TRTriangle(3, 4, 5);
            TRTriangle t2 = new TRTriangle(4, 3, 5);
            int comp = t1.CompareTo(t2);
            if (comp == 0)
            {
                Console.WriteLine("IsDoubleEquals PASSED");
            }
            else
            {
                Console.WriteLine("IsDoubleEquals FAILED");
            }
        }

        private static void TestMultiplyTriangles()
        {
            TRTriangle t1 = new TRTriangle(3, 4, 5);
            TRTriangle expected = new TRTriangle(6, 8, 10);
            TRTriangle actual = t1 * 2;
            if (IsDoubleEquals(actual.GetA(), expected.GetA()) &&
                IsDoubleEquals(actual.GetB(), expected.GetB()) &&
                IsDoubleEquals(actual.GetC(), expected.GetC()))
            {
                Console.WriteLine("TestMultiplyTriangles PASSED");
            }
            else
            {
                Console.WriteLine("TestMultiplyTriangles FAILED");
            }
        }
    }
}