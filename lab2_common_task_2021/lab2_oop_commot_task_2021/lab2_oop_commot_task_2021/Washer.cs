using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_oop_commot_task_2021
{
    class Washer
    {
        public static void Wash(Car car)
        {
            Console.WriteLine(car.getName() + " washed!");
        }
    }
}
