using CarPark.Cars;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarPark
{
    class Program
    {
        static void Main(string[] args)
        {       
            Autopark park = new Autopark();
            park.AddAllCarsFromFiles();
            Console.WriteLine("Welcome to the menu. Choose an item: " +
                "\n1.Calculate the cost of the Autopark" +
                "\n2.Sorting car fleet by fuel consumption" +
                "\n3.Find a car by speed" +
                "\n4.Would you like calculate the coast of your taxi" +
                "\n5.Show all cars" +
                "\n6.Delete car" +
                "\n7.Add new car" +
                "\n8.Exite");
             int number = Int32.Parse(Console.ReadLine());
             switch (number)
                {
                    case 1:
                        park.PrintSumOfCars();
                        break;
                    case 2:
                        park.PrintCarsByRange();
                        break;
                    case 3:
                        park.PrintCarBySpeed();
                        break;
                    case 4:
                        park.PrintYourCostOfTaxi();
                        break;
                    case 5:
                        park.PrintAllCars();
                        break;
                    case 6:
                        park.DeleteCar();
                        break;
                    case 7:
                        park.AddNewCar();
                        break;
                    default: return;
             }
            Console.ReadLine();
        }
    }
}
