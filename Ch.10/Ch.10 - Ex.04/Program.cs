using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._10___Ex._04
{

    public class MyCopyableClass
    {

        private string test;
        
        public MyCopyableClass()
        {

            test = "Test!";
        
        }

        public MyCopyableClass GetCopy()
        {

            return (MyCopyableClass)MemberwiseClone();

        }

        public void DisplayString()
        {

            Console.WriteLine(test);

        }

        public string MyContainedString
        {

            get
            {

                return test;

            }
            set
            {

                test = value;

            }

        }

    }
    
    
    class Program
    {
        static void Main(string[] args)
        {

            MyCopyableClass class1 = new MyCopyableClass();
            class1.MyContainedString = "Class 1 Test";

            MyCopyableClass class2 = class1.GetCopy();
            class2.MyContainedString = "Class 2 Test";

            class1.DisplayString();
            class2.DisplayString();

            Console.ReadKey();
        
        }
    }
}
