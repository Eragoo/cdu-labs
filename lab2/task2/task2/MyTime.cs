using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace task2
{
    public class MyTime
    {
        protected int hour;
        protected int minute;
        protected int second;
        public const int SEC_IN_MIN = 60;

        public static MyTime from(int hour, int minute, int second)
        {
            return new MyTime(hour, minute, second);
        }
        public MyTime(int hour, int minute, int second)
        {
            ValidateInputParams(hour, minute, second);
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public MyTime(int sec)
        {
            second = sec % SEC_IN_MIN;
            hour = sec / (SEC_IN_MIN * SEC_IN_MIN) % 24;
            minute = sec % (SEC_IN_MIN * SEC_IN_MIN) / SEC_IN_MIN;
        }

        public int TimeSinceMidnight()
        {
            return GetSecondsFromMidnight();
        }

        public static MyTime TimeSinceMidnight(int t)
        {
            return new MyTime(t);
        }

        public MyTime AddSeconds(int seconds)
        {
            int sec = GetSecondsFromMidnight() + seconds;
            return new MyTime(sec);
        }

        public MyTime AddOneMin()
        {
            return AddSeconds(SEC_IN_MIN);
        }

        public MyTime AddOneSec()
        {
            return AddSeconds(1);
        }

        public MyTime AddOneHour()
        {
            return AddSeconds(SEC_IN_MIN * SEC_IN_MIN);
        }

        public static String WhatLesson(MyTime t)
        {
            if (t.IsBetween(MyTime.from(8,0,0), MyTime.from(9,20,0)))
            {
                return "This is 1 Lecture";
            }
            if (t.IsBetween(MyTime.from(9,40,0), MyTime.from(11,0,0)))
            {
                return "This is 2 Lecture";
            }
            if (t.IsBetween(MyTime.from(11,20,0), MyTime.from(12,40,0)))
            {
                return "This is 3 Lecture";
            }
            if (t.IsBetween(MyTime.from(13,0,0), MyTime.from(14,20,0)))
            {
                return "This is 4 Lecture";
            }
            if (t.IsBetween(MyTime.from(14,40,0), MyTime.from(16,0,0)))
            {
                return "This is 5 Lecture";
            }

            return "There is chill time";
        }

        public Boolean IsBetween(MyTime start, MyTime end)
        {
            int m1 = end.GetSecondsFromMidnight() - GetSecondsFromMidnight();
            int m2 = GetSecondsFromMidnight() - start.GetSecondsFromMidnight();

            if (m1 >= 0 && m2 >= 0)
            {
                return true;
            }
            return false;
        }

        public static MyTime operator -(MyTime t1, MyTime t2)
        {
            return new MyTime(Math.Abs(t1.GetSecondsFromMidnight() - t2.GetSecondsFromMidnight()));
        }

        public override string ToString()
        {
            return String.Format("{0:d}:{1:d2}:{2:d2}", hour, minute, second);
        }

        private void ValidateInputParams(int h, int m, int s)
        {
            if (h < 0 || h > 23 || m < 0 || m > 59 || s < 0 || s > 59)
            {
                throw new Exception("Input params validation failed");
            }
        }


        private int GetSecondsFromMidnight()
        {
            return hour * SEC_IN_MIN * SEC_IN_MIN + second + minute * SEC_IN_MIN;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            MyTime t = (MyTime) obj;
            if (t.hour == hour && t.minute == minute && t.second == second)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return minute.GetHashCode() + hour.GetHashCode() + second.GetHashCode();
        }
    }
}