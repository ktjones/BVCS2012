using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._06___Ex._05
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

            public string itemInfo()
            {
                
                string info = "Order Information: " + Convert.ToString(unitCount) + " " + itemName + " items at $" + Convert.ToString(unitCost) + " each, total cost $" + Convert.ToString(totalPrice());

                return info;
            }

        }
                
        static void Main(string[] args)
        {

            order Todd = new order();
            //int count, cost;
            //string name;

            Console.Write("\nEnter the item Name: ");
            Todd.itemName = Console.ReadLine();

            Console.Write("\nEnter the Count: ");
            Todd.unitCount = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nEnter the Cost: ");
            Todd.unitCost = Convert.ToDouble(Console.ReadLine());

           
            Console.WriteLine("\n{0}",Todd.itemInfo());

            Console.ReadKey();

        }
    }
}
