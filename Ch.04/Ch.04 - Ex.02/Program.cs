using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._04___Ex._02
{
    class Program
    {
        static void Main(string[] args)
        {

            int v1;
            int v2;
            bool flag = false;

            do
            {

                Console.WriteLine("Enter the first Number (> than 10, Please): ");
                v1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the first Number (> than 10, Please): ");
                v2 = Convert.ToInt32(Console.ReadLine());
                if (v1 <= 10 && v2 <= 10)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }

            }
            while (!flag);

            Console.WriteLine("You entered {0} and {1}", v1, v2);
            Console.ReadKey(); 
        
        }
    }
}
