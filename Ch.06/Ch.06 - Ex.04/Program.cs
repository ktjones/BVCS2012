using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._06___Ex._04
{
    class Program
    {

        struct order
        {
            public string itemName;
            public double unitCount;
            public double unitCost;

            public double totalPrice()
            {
                return unitCount * unitCost;
            }

        }
                
        static void Main(string[] args)
        {

            order Todd = new order();
            //int count, cost;
            //string name;

            Console.Write("\nEnter the Count: ");
            Todd.unitCount = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nEnter the Cost: ");
            Todd.unitCost = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nThe Total Cost is: {0}", Todd.totalPrice());

            Console.ReadKey();

        }
    }
}
