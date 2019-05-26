using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var number = InputChek();
                var array = GetTable(number);              
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
                int num = Int32.Parse(Console.ReadLine());
                return num;                            
            }
            catch (FormatException)
            {
                Console.WriteLine("The input string had the wrong format.");
            }
            return InputChek();
        }
      
        static long[] GetTable(int number)
        {
            long[] arr = new long[10];
            for(int i=0; i<10; i++)
            {
                arr[i] = number * (i+1);
                Console.WriteLine(number + " * " + (i + 1) + " = " + arr[i]);
            }
            return arr;
        }
    }
}
