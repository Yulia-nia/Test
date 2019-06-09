using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace CarPark.Cars
{
    public class Car
    {
        public string Model { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public double Fuel { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string model, int price, int year, double fuel, int spead)
        {
            Model = model;
            Price = price;
            Year = year;
            Fuel = fuel;
            MaxSpeed = spead;
        }    

    }
}
