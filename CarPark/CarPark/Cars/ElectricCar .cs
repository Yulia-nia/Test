using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.Cars
{
    public class ElectricCar : Car
    {
        public int ChargingTime { set; get; }
        public long LifetimeBattery { set; get; }


        public ElectricCar(string model, int price, int year, double fuel, int spead, int chargingTime, long lifetimeBattery) 
            : base(model, price, year, fuel, spead)
        {
            ChargingTime = chargingTime;
            LifetimeBattery = lifetimeBattery;
        }
        
    }
}
