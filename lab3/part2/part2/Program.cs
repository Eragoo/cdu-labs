using System;
using System.Collections.Generic;

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
            TestEqualsInHashSet();
            TestDifferenceInHashSet();
            
            Console.WriteLine("\r\nPYRAMID WITH COLOR TESTS: \r\n");
            TestColorEqualsInHashSet();
            
            Console.WriteLine("\r\nPYRAMID WITH COLOR TESTS (Equals overriden ): \r\n");
            TestColorEqualsInHashSetEqualsOverriden();
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
        
        private static void TestEqualsInHashSet()
        {
            TRPiramid t1 = new TRPiramid(3, 4, 5, 1);
            TRPiramid t2 = new TRPiramid(3, 4, 5, 1);
            HashSet<TRPiramid> set = new HashSet<TRPiramid>();
            set.Add(t1);
            set.Add(t2);

            if (set.Count == 1)
            {
                Console.WriteLine("TestEqualsInHashSet PASSED");
            }
            else
            {
                Console.WriteLine("TestEqualsInHashSet FAILED");
            }
        }
        
        
        private static void TestDifferenceInHashSet()
        {
            TRPiramid t1 = new TRPiramid(3, 4, 5, 1);
            TRPiramid t2 = new TRPiramid(3, 4, 5, 2);
            HashSet<TRPiramid> set = new HashSet<TRPiramid>();
            set.Add(t1);
            set.Add(t2);

            if (set.Count == 1)
            {
                Console.WriteLine("TestDifferenceInHashSet FAILED");
            }
            else
            {
                Console.WriteLine("TestDifferenceInHashSet PASSED");
            }
        }
        
        private static void TestColorEqualsInHashSet()
        {
            TRCPiramid t1 = new TRCPiramid(3, 4, 5, 2, "red");
            TRCPiramid t2 = new TRCPiramid(3, 4, 5, 2, "green");
            TRCPiramid t3 = new TRCPiramid(3, 4, 5, 2, "blue");

            HashSet<TRPiramid> set = new HashSet<TRPiramid>();
            set.Add(t1);
            set.Add(t2);
            set.Add(t3);

            //Fails because of equals() method
            if (set.Count == 1)
            {
                Console.WriteLine("TestColorEqualsInHashSet FAILED");
            }
            else
            {
                Console.WriteLine("TestColorEqualsInHashSet PASSED");
            }
        }
        private static void TestColorEqualsInHashSetEqualsOverriden()
        {
            TRCEPiramid t1 = new TRCEPiramid(3, 4, 5, 2, "red");
            TRCEPiramid t2 = new TRCEPiramid(3, 4, 5, 2, "green");
            TRCEPiramid t3 = new TRCEPiramid(3, 4, 5, 2, "blue");

            HashSet<TRCEPiramid> set = new HashSet<TRCEPiramid>();
            set.Add(t1);
            set.Add(t2);
            set.Add(t3);

            if (set.Count == 1)
            {
                Console.WriteLine("TestColorEqualsInHashSetEqualsOverriden FAILED");
            }
            else if (set.Count == 3)
            {
                
                Console.WriteLine("TestColorEqualsInHashSetEqualsOverriden PASSED");
            }
        }
    }
}