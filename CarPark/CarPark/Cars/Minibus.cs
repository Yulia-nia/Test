using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Cars
{
    class Minibus : Car
    {
        public bool IsTripsToAnotherCity { get; set; }
                
        public Minibus(string str): base(str)
        {
            string[] parts = str.Split("; ");
            IsTripsToAnotherCity = bool.Parse(parts[7]);
        }

        public Minibus()
        {
        }

        public override void Driving(double costOfKilometer, double firstCost, double distance)
        {
            double res = 2*costOfKilometer + (firstCost * distance);
            Console.WriteLine("Your cost is: " + res);
        }
    }
}
