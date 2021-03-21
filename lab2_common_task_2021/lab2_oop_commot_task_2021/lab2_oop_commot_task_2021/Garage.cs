using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_oop_commot_task_2021
{
    class Garage
    {
        public delegate void WashCar(Car car);

        private WashCar washer;

        private List<Car> cars = new List<Car>();

        public Garage(List<Car> cars, WashCar washer)
        {
            this.cars = cars;
            this.washer = washer;
        }

        public void addCar(Car car) {
            cars.Add(car);
        }

        public bool removeCar(Car car) {
            return cars.Remove(car);
        }

        public void washAllCars()
        {
            cars.ForEach(car=>washer(car));
        }
    }
}
