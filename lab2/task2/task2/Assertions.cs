using System;

namespace task2
{
    public static class Assertions
    {
        public static void AssertEquals(int expected, int actual, String testName)
        {
            if (expected == actual)
            {
                Console.WriteLine(testName + " PASSED");
            }
            else
            {
                Console.WriteLine(testName + " FAILED");
            }
        }
        
        public static void AssertEquals(String expected, String actual, String testName)
        {
            if (expected.Equals(actual))
            {
                Console.WriteLine(testName + " PASSED");
            }
            else
            {
                Console.WriteLine(testName + " FAILED");
            }
        }

        public static void AssertEquals(MyTime expected, MyTime actual, String testName)
        {
            if (expected.Equals(actual))
            {
                Console.WriteLine(testName + " PASSED");
            }
            else
            {
                Console.WriteLine(testName + " FAILED");
            }
        }
    }
}