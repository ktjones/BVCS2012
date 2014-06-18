using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch._09___Example_02_Lib;

namespace Ch._09___Example_02
{
    class Program
    {
        static void Main(string[] args)
        {

            MyExternalClass myObj = new MyExternalClass();
            Console.WriteLine(myObj.ToString());
            Console.ReadKey();
        
        }
    }
}
