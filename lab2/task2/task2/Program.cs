using System;

namespace task2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            ToStringTest();
            TimeFromMidnightTest();
            TimeSinceMidnightTest();
            TimeSecConstructorTest();
            AddSecondsTest();
            MinusTimeTest();
            WhatLessonTest();
        }

        static void ToStringTest()
        {
            MyTime t = new MyTime(1, 2, 3);
            String expected = "1:02:03";
            String actual = t.ToString();
            Assertions.AssertEquals(expected, actual, "ToStringTest");
        }

        static void TimeFromMidnightTest()
        {
            MyTime t = new MyTime(1, 2, 3);
            int expected = 1 * 60 * 60 + 2 * 60 + 3;
            int actual = t.TimeSinceMidnight();
            Assertions.AssertEquals(expected, actual, "TimeFromMidnightTest");
        }

        static void TimeSinceMidnightTest()
        {
            MyTime actual = MyTime.TimeSinceMidnight(1234);
            MyTime expected = new MyTime(0, 20, 34);
            Assertions.AssertEquals(expected, actual, "TimeSinceMidnightTest");
        }

        static void TimeSecConstructorTest()
        {
            MyTime actual = new MyTime(25 * 60 * 60 + 120 + 1);
            MyTime expected = new MyTime(1, 2, 1);
            Assertions.AssertEquals(expected, actual, "TimeSecConstructorTest");
        }
        
        static void AddSecondsTest()
        {
            MyTime t = new MyTime(23,59,59);
            MyTime actual = t.AddSeconds(2);
            MyTime expected = new MyTime(0, 0, 1);
            Assertions.AssertEquals(expected, actual, "AddSecondsTest");
        }

        static void MinusTimeTest()
        {
            MyTime t1 = new MyTime(120);
            MyTime t2 = new MyTime(123);
            MyTime actual = t1 - t2;
            MyTime expected = new MyTime(0, 0, 3);
            Assertions.AssertEquals(expected, actual, "MinusTimeTest");
        }
        
        static void WhatLessonTest()
        {
            MyTime t1 = new MyTime(8,10,12);
            String actual = MyTime.WhatLesson(t1);
            String expected = "This is 1 Lecture";
            Assertions.AssertEquals(expected, actual, "WhatLessonTest");
        }
    }
}