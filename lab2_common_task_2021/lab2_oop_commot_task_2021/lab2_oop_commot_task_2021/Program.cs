using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_oop_commot_task_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            ArraySearchTest();
            Console.ReadKey();
        }

        static void GarageTest()
        {
            List<Car> cars = new List<Car>()
            {
                new Car("Car1"), new Car("Car2"), new Car("Car3")
            };
            Garage garage = new Garage(cars, Washer.Wash);
            garage.washAllCars();

            Console.ReadKey();
        }

        static void TimerTest()
        {
            Timer.setInterval(2, () => Console.WriteLine(DateTime.Now + ": Hello!"));
        }

        static void ArraySearchTest()
        {
            Int16[] arr = { 1, 2, 3, 4, 5, 6, 7 };

            new Arrays<Int16>(arr).printMatchesElements((el) => el % 7 == 0)
                .printMatchesElements((el) => el % 3 == 0);
        }
    }
}
