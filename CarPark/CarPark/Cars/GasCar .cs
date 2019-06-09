using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Cars
{
    internal class GasCar : Car
    {
        public int FuelEconomy { set; get; }
        public GasCar (string model, int price, int year, double fuel, int spead, int fuelEconomy)
            :base (model, price, year, fuel, spead)
        {
            FuelEconomy = fuelEconomy;
        }
       
    }
}
