using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var day = GetWeek(InputChek());
                Console.WriteLine($"You input: {day}");
                Console.WriteLine("Would you like to enter another number? (y/n)");
                var answer = Console.ReadLine();
                if (!(answer.Equals("y") || answer.Equals("Y"))) break;
            }
        }

        static int InputChek()
        {
            try
            {
                Console.WriteLine("Input number:");
                int number = Int32.Parse(Console.ReadLine());
                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("The input string had the wrong format.");
            }
            return InputChek();
        }

        static string GetWeek(int number)
        {
            switch (number)
            {
                case 1:
                    return "Monday";
                case 2:
                    return "Tuesday";
                case 3:
                    return "Wednesday";
                case 4:
                    return "Thursday";
                case 5:
                    return "Friday";
                case 6:
                    return "Saturday";
                case 7:
                    return "Sunday";
                default:
                    return "Error! There are only 7 days of the week!";
            }
        }
    }
}
