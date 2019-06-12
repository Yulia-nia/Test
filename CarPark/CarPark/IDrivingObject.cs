using CarPark.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark
{
    public interface IDrivingObject
    {
        void Driving(double costOfKilometer, double firstCost, double distance);       
    }
}
