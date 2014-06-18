using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch._09___Ex._04_Lib;

namespace Ch._09___Ex._05
{
    class Program
    {

        static void AddPassenger(IPassengerCarrier Ipass)
        {

            Console.WriteLine(Ipass.ToString());

        }
        
        static void Main(string[] args)
        {

            PassengerTrain ptrain = new PassengerTrain();
            Compact cpact = new Compact();
            SUV suv = new SUV();
            Pickup pickup = new Pickup();

            AddPassenger(ptrain);
            AddPassenger(cpact);
            AddPassenger(suv);
            AddPassenger(pickup);

            Console.ReadKey();
        
        }
    }
}
