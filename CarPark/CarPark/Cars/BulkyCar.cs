using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Cars
{
    //class with machines for small shipments
    class BulkyCar : Car
    {
        public double LoadCapasity { get; set; }

        public BulkyCar(string str)
            : base(str)
        {
            string[] parts = str.Split(";");
            LoadCapasity = (int)double.Parse(parts[7]);
        }

        public BulkyCar()
        {
        }

        public override void Driving(double costOfKilometer, double firstCost, double distance)
        {
            double res = 0.5*costOfKilometer + (firstCost * distance);
            Console.WriteLine("Your cost is: " + res);
        }

    }
}
