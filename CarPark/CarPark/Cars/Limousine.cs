using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Cars
{
    class Limousine : Car
    {
        public double CarLength {get; set;}
        public bool IsCarForParty {get; set;}

        public Limousine(string str): base(str)
        {
            string[] parts = str.Split(";");
            CarLength = (int)double.Parse(parts[7]);
            IsCarForParty = bool.Parse(parts[8]);
        }

        public Limousine()
        {
        }

        public override void Driving(double costOfKilometer, double firstCost, double distance)
        {
            double res = 5*costOfKilometer + (firstCost * distance);
            Console.WriteLine("Your cost is: " + res);
        }
    }
}
