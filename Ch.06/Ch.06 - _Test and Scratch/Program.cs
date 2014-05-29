using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._06____Test_and_Scratch
{

    
    class Program
    {

        struct CustomerName
        {
            public string firstName, lastName;
            public int Name()
            {
                Console.WriteLine("{0} {1}", firstName, lastName);
                return 0;
            }
        }

        
        static int Main(string[] args)
        {

            CustomerName myCustomer;
            myCustomer.firstName = "John";
            myCustomer.lastName = "Franklin";
            myCustomer.Name();
        
            // End of Program
            Console.ReadKey();
            return 0;

        }
    }
}
