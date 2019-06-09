using CarPark.Cars;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPark
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> car = new List<Car>()
            {
                new Car("Audi", 3500, 2015, 26.0, 250),
                new Car("BMW", 2000, 2017, 32.0, 280),
                new ElectricCar("Volvo", 1500, 2012, 20.0, 150, 10, 35),
                new GasCar ("Lada", 3400, 2000, 27.0, 300, 30)
            };
            Console.WriteLine("Welcome to the menu. Choose an item: \n1.Calculate the cost of the Autopark" +
                "\n2.Sorting car fleet by fuel consumption" +
                "\n3.Find a car by speed" +
                "\n4.Exite");
            int number = Int32.Parse(Console.ReadLine());
            if(number==1)
            {              
                long carsCost = Autopark.CarsCost(car);
                Console.WriteLine($"Autopark total cost is ${carsCost}");
            }
            if (number == 2)
            {
                Console.WriteLine("Enter the minimum speed");
                int min = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter the maximum speed");
                int max = Int32.Parse(Console.ReadLine());
                Autopark.SearchBySpeed(car, min, max);
            }
            if (number == 3)
            {
                Autopark.SortByFuelOrderByDescending(car);
            }           
            else 
            {
                return;
            }
            Console.ReadKey();
        }
    }
}
