using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace lab2_oop_commot_task_2021
{
    class Timer
    {
        public delegate void Action();

        public static void setInterval(int t, Action callback)
        {
            while (true) {
                callback();
                Thread.Sleep(t * 1000);
            }
        }
    }
}
