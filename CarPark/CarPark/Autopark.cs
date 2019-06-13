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

        public void DeleteCar()
        {  
            Console.WriteLine("Choose one car:\n  1)Bulky Car\n  " +
                "2)Limousine\n  3)Minibus\n  4)Passenger Car");
            int num = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input the Model of Car");
            var str = Console.ReadLine();            
            switch (num)
            {
                case 1:
                    var path = @"C:\Users\user\source\repos\CarPark\TaxiPark\BulkyCars.txt";
                    DeleteCarInFile(path, str);
                    break;
                case 2:
                    var path1 = @"C:\Users\user\source\repos\CarPark\TaxiPark\Limousines.txt";
                    DeleteCarInFile(path1, str);
                    break;
                case 3:
                    var path2 = @"C:\Users\user\source\repos\CarPark\TaxiPark\Minibus.txt";
                    DeleteCarInFile(path2, str);
                    break;
                case 4:
                    string path3 = @"C:\Users\user\source\repos\CarPark\TaxiPark\PassengerCars.txt";
                    DeleteCarInFile(path3, str);
                    break;
            }
            Console.WriteLine("Your car is delete");
        }
        public void DeleteCarInFile(string path, string str)
        {
            List<string> file = File.ReadAllLines(path).ToList();
            var deleteCar = file.FirstOrDefault(i => i.StartsWith(str));
            var index = file.IndexOf(deleteCar);
            file.RemoveAt(index);
            File.WriteAllLines(path, file.ToArray());
        }
       

        public void AddNewCar()
        {          
            Console.WriteLine("Choose one car:\n  1)Bulky Car\n  " +
                "2)Limousine\n  3)Minibus\n  4)Passenger Car");
            int num = Int32.Parse(Console.ReadLine());
            switch(num)
            {
                case 1:
                    var path = @"C:\Users\user\source\repos\CarPark\TaxiPark\BulkyCars.txt";
                    Console.WriteLine("Input the Model of Car; Price; Year; Fuel Consumption; Average Speed; Number Of Passenger Seats; Is Child Seat; LoadCapasity");
                    string str = Console.ReadLine();                    
                    _taxiPark.Add(new BulkyCar(str));
                    AddCarInFile(path, str);
                    break;
                case 2:
                    var path1 = @"C:\Users\user\source\repos\CarPark\TaxiPark\Limousines.txt";
                    Console.WriteLine("Input the Model of Car; Price; Year; Fuel Consumption; Average Speed; Number Of Passenger Seats; Is Child Seat; Car Length; IsCarForParty");
                    string str1 = Console.ReadLine();                    
                    _taxiPark.Add(new Limousine(str1));                    
                    AddCarInFile(path1, str1);
                    
                    break;
                case 3:
                    var path2 = @"C:\Users\user\source\repos\CarPark\TaxiPark\Minibus.txt";
                    Console.WriteLine("Input the Model of Car; Price; Year; Fuel Consumption; Average Speed; Number Of Passenger Seats; Is Child Seat; Is Trips To Another City");
                    string str2 = Console.ReadLine();
                    _taxiPark.Add(new Minibus(str2));
                    AddCarInFile(path2, str2);
                    break;
                case 4:
                    var path3 = @"C:\Users\user\source\repos\CarPark\TaxiPark\PassengerCars.txt";
                    Console.WriteLine("Input the Model of Car; Price; Year; Fuel Consumption; Average Speed; Number Of Passenger Seats; Is Child Seat; IsSoberDriverService");
                    string str3 = Console.ReadLine();
                    _taxiPark.Add(new PassengerСar(str3));
                    AddCarInFile(path3, str3);
                    break;
            }
            Console.WriteLine("Your car is add");
        }

        public void AddCarInFile(string path, string str)
        {
            using (StreamWriter write = new StreamWriter(path, true, Encoding.Default))
            {
                write.WriteLine(str);
                write.Close();
            }
        }


        public void PrintAllCars()
        {
            IEnumerable<IDrivingObject> ShowAllCars = _taxiPark.Where(i => i is Car);
            PrintSomeCars(ShowAllCars);
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