using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            TextHandler tx = new TextHandler() { Path = @"C:\Users\user\source\repos\WorkWithFiles\Files\sample.txt" };
            Task.WaitAll(tx.Print(), tx.Creat());
        }       
    }
}
