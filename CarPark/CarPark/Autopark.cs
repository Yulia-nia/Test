using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using CarPark.Cars;
using System.Collections;
using System.IO;

namespace CarPark
{
    public class Autopark : IList<IDrivingObject>
    {
        public List<IDrivingObject> _taxiPark = new List<IDrivingObject>();        
        public void AddBulkyCarFromFile()
        {
            using (StreamReader sr = File.OpenText(@"C:\Users\user\source\repos\CarPark\TaxiPark\BulkyCars.txt"))
            {
                while(!sr.EndOfStream)
                {
                    _taxiPark.Add(new BulkyCar(sr.ReadLine()));
                }
            }
        }
        public void AddLimousineFromFile()
        {
            using (StreamReader sr = File.OpenText(@"C:\Users\user\source\repos\CarPark\TaxiPark\Limousines.txt"))
            {
                while (!sr.EndOfStream)
                {
                    _taxiPark.Add(new Limousine(sr.ReadLine()));
                }
            }
        }
        public void AddMinibusFromFile()
        {
            using (StreamReader sr = File.OpenText(@"C:\Users\user\source\repos\CarPark\TaxiPark\Minibus.txt"))
            {
                while (!sr.EndOfStream)
                {
                    _taxiPark.Add(new Minibus(sr.ReadLine()));
                }
            }
        }
        public void AddPassengerСarFromFile()
        {
            using (StreamReader sr = File.OpenText(@"C:\Users\user\source\repos\CarPark\TaxiPark\PassengerCars.txt"))
            {
                while (!sr.EndOfStream)
                {
                    _taxiPark.Add(new PassengerСar(sr.ReadLine()));
                }
            }
        }

        public void AddAllCarsFromFiles()
        {
            AddBulkyCarFromFile();
            AddMinibusFromFile();
            AddLimousineFromFile();
            AddPassengerСarFromFile();
        }

        #region IList
        public IDrivingObject this[int index] { get => _taxiPark[index]; set => _taxiPark[index] = value; }

        public int Count => _taxiPark.Count;

        public bool IsReadOnly => false;      

        public void Add(IDrivingObject item)
        {
            _taxiPark.Add(item);
        }

        public void Clear()
        {
            _taxiPark.Clear();
        }

        public bool Contains(IDrivingObject item)
        {
            return _taxiPark.Contains(item);
        }

        public void CopyTo(IDrivingObject[] array, int arrayIndex)
        {
            _taxiPark.CopyTo(array, arrayIndex);
        }       

        public IEnumerator<IDrivingObject> GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(IDrivingObject item)
        {
            return _taxiPark.IndexOf(item);
        }

        public void Insert(int index, IDrivingObject item)
        {
            _taxiPark.Insert(index, item);
        }

        public bool Remove(IDrivingObject item)
        {
            return _taxiPark.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _taxiPark.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
               
        //стоимость автопарка
        public long GloabalCarsCpacity => _taxiPark.Where(i => i is Car)
            .Sum(i => (i as Car).Price);

        public void PrintSumOfCars()
        {       
            Console.WriteLine($"Autopark total cost is {GloabalCarsCpacity}" );
        }
     
        //сортировка автомобией
        public IEnumerable<IDrivingObject> SortedCarsByRange 
            => _taxiPark.Where(i => i is Car)
        .OrderBy(i => (i as Car).FuelConsumption); 

        public void PrintCarsByRange()
        {          
            PrintSomeCars(SortedCarsByRange);
        }
        
        //НАЙТИ ПО СКОРОСТИ
        public IEnumerable<IDrivingObject> GetCarBySpeed(double min, double max)
            => _taxiPark.Where(i => (i is Car)
                                    && (i as Car).AverageSpeed >= min
                                    && (i as Car).AverageSpeed <= max);
        public void PrintCarBySpeed()
        {
            Console.WriteLine("Enter the minimum speed");
            int min = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the maximum speed");
            int max = Int32.Parse(Console.ReadLine());
            IEnumerable<IDrivingObject> items = GetCarBySpeed(min, max);
            if (items != null)
            {
                PrintSomeCars(items);
            }
            else
                Console.WriteLine("Error!");
        }

        public void PrintYourCostOfTaxi()
        {
            Console.WriteLine("Input your cost of kilometer.");
            var costOfKilometer = double.Parse(Console.ReadLine());
            Console.WriteLine("Input your cost of first kilometer.");
            var firstCost = double.Parse(Console.ReadLine());
            Console.WriteLine("Input your distance of kilometer.");
            var distance = double.Parse(Console.ReadLine());
            Console.WriteLine("Choose one car: " +
                "\n  1)Bulky Car" +
                "\n  2)Limousine" +
                "\n  3)Minibus" +
                "\n  4)Passenger Car");
            var number = Int32.Parse(Console.ReadLine());
            switch(number)
            {
                case 1:
                    BulkyCar bulkCar = new BulkyCar();
                    bulkCar.Driving(costOfKilometer, firstCost, distance);
                    break;                    
                case 2:
                    Limousine limousine = new Limousine();
                    limousine.Driving(costOfKilometer, firstCost, distance);
                    break;
                case 3:
                    Minibus minibus = new Minibus();
                    minibus.Driving(costOfKilometer, firstCost, distance);
                    break;
                case 4:
                    PassengerСar passCar = new PassengerСar();
                    passCar.Driving(costOfKilometer, firstCost, distance);
                    break;
            }          
        }

        public void PrintSomeCars(IEnumerable<IDrivingObject> cars)
        {
            foreach (var item in cars)
            {
                var car = item as Car;
                var largeCar = item as BulkyCar;
                var limousine = item as Limousine;
                var pasCar = item as PassengerСar;
                var minibus = item as Minibus;
                Console.Write($"\n\nModel: {car.Model}, Price: {car.Price}, Year: {car.Year}," +
                    $" FuelConsumption: {car.FuelConsumption},\nAverageSpeed: {car.AverageSpeed}," +
                    $" Number Of Passenger Seats: {car.NumberOfPassengerSeats}, Is Child Seat: {car.IsChildSeat},");
                
                if (largeCar?.LoadCapasity!=null)
                {
                    Console.Write($" Load Capasity: {largeCar.LoadCapasity}, ");
                }
                if (limousine?.CarLength != null)
                {
                    Console.Write($"Car Length: {limousine.CarLength}," +
                        $" Is Car For Party: {limousine.IsCarForParty}, ");
                }
                if (minibus?.IsTripsToAnotherCity != null)
                {
                    Console.Write($"Is Trips To Another City: {minibus.IsTripsToAnotherCity}, ");
                }
                if (pasCar?.IsSoberDriverService != null)
                {
                    Console.Write($"Is Sober Driver Service: {pasCar.IsSoberDriverService}");
                }  
            }
        }       
    }
}