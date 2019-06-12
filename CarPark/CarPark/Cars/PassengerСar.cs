using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Cars
{
    class PassengerСar : Car
    {
        public bool IsSoberDriverService { get; set; }
        
        public PassengerСar(string str): base(str)
        {
            string[] parts = str.Split(";");
            IsSoberDriverService = bool.Parse(parts[7]);
        }

        public PassengerСar()
        {
        }

        public override void Driving(double costOfKilometer, double firstCost, double distance)
        {
            double res = 1.5*costOfKilometer + (firstCost * distance);
            Console.WriteLine("Your cost is: " + res);
        }
    }
}
