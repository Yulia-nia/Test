using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using CarPark.Cars;

namespace CarPark
{
    public class Autopark
    {
        public static long CarsCost(List<Car> cars)
        {
            long summ = 0;
            foreach (Car car in cars)
            {
                summ += car.Price;
            }
            return summ;
        }
        public static void SearchBySpeed(List<Car> cars, int min, int max)
        {
            foreach (Car item in cars)
            {
                if (item.MaxSpeed >= min && item.MaxSpeed <= max)
                {
                    Console.WriteLine("Model: {0}   Price: {1}  Year: {2}  Fuel: {3}  Speed: {4}", item.Model, item.Price, item.Year, item.Fuel, item.MaxSpeed);
                }
            }
        }

         
        public static void SortByFuelOrderByDescending(List<Car> cars)
        {
            var sort = cars.OrderByDescending(i => i.Fuel);
            foreach (var car in sort)
            {
                Console.WriteLine("Model: {0}   Price: {1}  Year: {2}  Fuel: {3}  Speed: {4}", car.Model, car.Price, car.Year, car.Fuel, car.MaxSpeed);
            }
        }
    }
    }

