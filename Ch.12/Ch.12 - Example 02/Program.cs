using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._12___Example_02
{
    class Program
    {
        static void Main(string[] args)
        {

            bool flag;
            
            List<Animal> animalCollection = new List<Animal>();
            List<Animal> animalCollection2 = new List<Animal>();
            
            animalCollection.Add(new Cow("Jack"));
            animalCollection.Add(new Chicken("Vera"));
            animalCollection2.Add(new Chicken("Vera"));
            animalCollection2.Add(new Cow("Jack"));


            foreach (Animal myAnimal in animalCollection)
            {
                myAnimal.Feed();
            }
           
            Console.ReadKey();
            
            

        }
    }
}
