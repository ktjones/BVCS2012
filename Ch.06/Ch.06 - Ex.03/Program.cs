using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._06___Ex._03
{
    class Program
    {

        delegate string consoleReadLineDelegate();
        
        static void Main(string[] args)
        {

            //Create a delegate and use it to impersonate the Console.ReadLine() function when asking for user input.

            consoleReadLineDelegate readLine = new consoleReadLineDelegate(Console.ReadLine);

            double x1, x2;
            string line;

            Console.WriteLine("Enter the first number: ");
            x1 = Convert.ToDouble(readLine());

            Console.WriteLine();

            Console.WriteLine("Enter the second number: ");
            x2 = Convert.ToDouble(readLine());

            Console.WriteLine();
            Console.WriteLine("The first number is {0}, the second number is {1}", x1, x2);

            Console.ReadKey();

        }
    }
}
