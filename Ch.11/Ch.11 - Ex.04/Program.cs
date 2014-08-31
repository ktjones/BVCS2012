using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._11___Ex._04 
{
    class Program
    {
        static void Main(string[] args)
        {

            People myPeople = new People();

            Person Bob = new Person();
            Bob.Name = "Bob";
            Bob.Age = 32;

            Person Sally = new Person();
            Bob.Name = "Sally";
            Bob.Age = 64;


            //myPeople.add(new Person("Bob", 32));
            
            foreach (int age in myPeople.Ages)
            {

                Console.WriteLine(age);

            }

            Console.ReadKey();
        
        }
    }
}
