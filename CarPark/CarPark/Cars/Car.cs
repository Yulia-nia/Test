using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace CarPark.Cars
{
    public  class Car : IDrivingObject
    {
        public string Model { get; set; }
        public long Price { get; set; }
        public int Year { get; set; }
        public double FuelConsumption { get; set; }  
        public int AverageSpeed { get; set; } 
        public int NumberOfPassengerSeats { get; set; }
        public bool  IsChildSeat { get; set; }

        public Car(string str)
        {
            string[] parts = str.Split("; ");
            Model = parts[0];
            Price = long.Parse(parts[1]);
            Year = int.Parse(parts[2]);
            FuelConsumption = double.Parse(parts[3]);
            AverageSpeed = int.Parse(parts[4]);
            NumberOfPassengerSeats = int.Parse(parts[5]);
            IsChildSeat = bool.Parse(parts[6]);
        }

        public Car()
        {
        }

        public virtual void Driving(double costOfKilometer, double firstCost, double distance)
        {
            double res = costOfKilometer + (firstCost * distance);
            Console.WriteLine("Your cost is: " + res);
        }
    }
}
