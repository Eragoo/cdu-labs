using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_oop_commot_task_2021
{
    class Arrays<T>
    {
        public delegate bool MatchFunc<T>(T el);
        private T[] arr;

        public Arrays(T[] arr)
        {
            this.arr = arr;
        }

        public void printMatchesElements(MatchFunc<T> isMatch) {
            for(int i = 0; i < arr.Length; i++)
            {
                if (isMatch(arr[i])) {
                    Console.WriteLine(arr[i].ToString());
                }
            }
        }
    }
}
