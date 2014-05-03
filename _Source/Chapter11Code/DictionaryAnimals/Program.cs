using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAnimals
{
   class Program
   {
      static void Main(string[] args)
      {
         Animals animalCollection = new Animals();
         animalCollection.Add("Jack", new Cow("Jack"));
         animalCollection.Add("Vera", new Chicken("Vera"));
         foreach (Animal myAnimal in animalCollection)
         {
            Console.WriteLine("New {0} object added to custom collection, " +
                              "Name = {1}", myAnimal.ToString(), myAnimal.Name);
         }
         Console.ReadKey();
      }
   }
}
